using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SonicState.Contracts;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Entities;
using SonicState.Models;
using SonicState.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Services
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository audioRepository;
        private readonly AudioAnalyzer audioAnalyzer;
        private readonly FileStorage fileStorage;
        private readonly IServiceProvider provider;
        private readonly IBackgroundTaskQueue queue;
        private readonly IClaimAccessor currentUser;

        public AudioService(
            IAudioRepository audioRepository,
            AudioAnalyzer audioAnalyzer, 
            FileStorage fileStorage,
            IServiceProvider provider,
            IBackgroundTaskQueue queue,
            IClaimAccessor currentUser)
        {
            this.audioRepository = audioRepository;
            this.audioAnalyzer = audioAnalyzer;
            this.fileStorage = fileStorage;
            this.queue = queue;
            this.provider = provider;
            this.currentUser = currentUser;
        }

        public async Task AddAsync(IFormFile audio)
        {
            var guid = GenerateGuid();
            var storageName = guid + audio.FileName;

            await fileStorage.Upload(audio, storageName);
            AddAnalyzedAudioToDb(audio.FileName, guid, storageName);
        }

        public IEnumerable<AudioDetails> GetAll() => audioRepository.GetAll();

        private async Task AddAnalyzedAudioToDb(string audioName, string guid, string storageName)
        {
            queue.QueueBackgroundWorkItem(async token =>
            {
                var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var Dbcontext = ProvideAudioRepository(scope);
                    var analysis = await Analyze(await GetStorageURL(storageName));
                    var audioEntity = GenerateAudioEntity(analysis, audioName, guid);
                    await Dbcontext.Add(audioEntity);
                    await Dbcontext.SaveChanges();
                }
            });
        }

        private IAudioRepository ProvideAudioRepository(IServiceScope scope) => scope.ServiceProvider.GetService<IAudioRepository>();

        private Audio GenerateAudioEntity(AudioAnalysis audioAnalysis, string audioName, string guid)
        {
            var audio = new Audio();
            audio.Id = guid;
            audio.Name = audioName;
            audio.Key = audioAnalysis.Key;
            audio.Bpm = audioAnalysis.Tempo;
            audio.UserId = currentUser.Id;
            audio.ChordUnits = audioAnalysis.Chords.Select(c => new ChordUnit { Time = c.Key, Chord = c.Value }).OrderBy(c => c.Time).ToList();
            return audio;
        }

        private async Task<string> GetStorageURL(string storageName) => await fileStorage.GenerateURL(storageName);

        private async Task<AudioAnalysis> Analyze(string audioURL) => await audioAnalyzer.Analyze(audioURL);

        private string GenerateGuid() => Guid.NewGuid().ToString();
    }
}
