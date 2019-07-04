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
       
        public AudioService
            (IAudioRepository audioRepository, AudioAnalyzer audioAnalyzer, FileStorage fileStorage, IServiceProvider provider,IBackgroundTaskQueue queue)
        {
            this.audioRepository = audioRepository;
            this.audioAnalyzer = audioAnalyzer;
            this.fileStorage = fileStorage;
            this.queue = queue; 
            this.provider = provider;
        }

        public async Task AddAsync(IFormFile audio)
        {
            var guid= GenerateGuid();
            await fileStorage.Upload(audio, guid);
            AddAnalyzedAudioToDb(audio.FileName, guid);
        }
        public IEnumerable<AudioDetails> GetAll()
        {
            return audioRepository.GetAll();
        }
        private async Task AddAnalyzedAudioToDb(string audioName, string guid)
        {
            queue.QueueBackgroundWorkItem(async token =>
            {
                var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var Dbcontext = await ProvideAudioRepository(scope);
                    var analysis = await Analyze(await GetStorageURL(audioName));
                    var audioEntity = await GenerateAudioEntity(analysis, audioName, guid);
                    await Dbcontext.Add(audioEntity);
                    await Dbcontext.SaveChanges();
                }
            });
        }
        private async Task<IAudioRepository> ProvideAudioRepository(IServiceScope scope)
        {
            return scope.ServiceProvider.GetService<IAudioRepository>();
        }
        private async Task<Audio> GenerateAudioEntity (AudioAnalysis audioAnalysis, string audioName, string guid)
        {
            var audio = new Audio();
            audio.Id = guid;
            audio.Name = audioName;
            audio.Key = audioAnalysis.Key;
            audio.Bpm = audioAnalysis.Tempo;
            audio.ChordUnits = await CreateChordUnitCollection(audioAnalysis.Chords);
            return audio;
        }
        private async Task<string> GetStorageURL(string audioName)
        {
            return await fileStorage.GenerateURL(audioName);
        }
        private async Task<AudioAnalysis> Analyze (string audioURL)
        {
            return await audioAnalyzer.Analyze(audioURL);
        }
        private async Task<ICollection<ChordUnit>> CreateChordUnitCollection (IDictionary<double, string> chords)
        {
            var chordCollection = new List<ChordUnit>();

            foreach (KeyValuePair<double, string> pair in chords.OrderBy(c=> c.Key))
            {
                chordCollection.Add(new ChordUnit { Time = pair.Key, Chord = pair.Value });
            }

            return chordCollection;
        }
        private string GenerateGuid()
        {
            var guid = Guid.NewGuid().ToString();
            return guid;
        }
    }
}
