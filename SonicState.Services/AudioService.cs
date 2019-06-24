using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SonicState.Contracts;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Entities;
using SonicState.Models;
using SonicState.SonicAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SonicState.Services
{
    public class AudioService : IAudioService
    {

        private readonly IAudioRepository audioRepository;
        private readonly AudioAnalyzer audioAnalyzer;
        private readonly FileStorage fileStorage;
        private readonly IServiceProvider provider;
       


        public AudioService
            (IAudioRepository audioRepository, AudioAnalyzer audioAnalyzer, FileStorage fileStorage, IServiceProvider provider)
        {
            this.audioRepository = audioRepository;
            this.audioAnalyzer = audioAnalyzer;
            this.fileStorage = fileStorage;

            this.provider = provider;
        }

        public async Task AddAsync(IFormFile audio)
        {
            await fileStorage.Upload(audio);
            AddAnalyzedObjectToDb(audio.FileName);
        }
        private async Task AddAnalyzedObjectToDb(string audioName)
        {
            Task.Factory.StartNew(async () =>
            {
                Thread.CurrentThread.IsBackground = true;
                var serviceScopeFactory = provider.GetRequiredService<IServiceScopeFactory>();
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var Dbcontext = await ProvideAudioRepository(scope);
                    var analysis = await Analyze(await GetStorageURL(audioName));
                    var audioEntity = await GenerateAudioEntity(analysis,audioName);
                    await Dbcontext.Add(audioEntity);
                    await Dbcontext.SaveChanges();
                }
            }).Start();
        }
        private async Task<IAudioRepository> ProvideAudioRepository(IServiceScope scope)
        {
            return scope.ServiceProvider.GetService<IAudioRepository>();
        }
        private async Task<Audio> GenerateAudioEntity (AudioAnalysis audioAnalysis, string audioName)
        {
            var audio = new Audio();
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
    }
}
