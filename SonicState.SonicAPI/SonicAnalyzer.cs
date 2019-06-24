using SonicState.Contracts;
using SonicState.Models;
using SonicState.SonicAPI.Sonic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.SonicAPI
{
    public class SonicAnalyzer : AudioAnalyzer
    {
        private SonicChordsAnalyzer chordsAnalyzer;
        private SonicTempoAnalyzer tempoAnalyzer;
        private SonicKeyAnalyzer keyAnalyzer;

        public SonicAnalyzer()
        {
            this.chordsAnalyzer = new SonicChordsAnalyzer();
            this.tempoAnalyzer = new SonicTempoAnalyzer();
            this.keyAnalyzer = new SonicKeyAnalyzer();
        }

        //public IEnumerable<Chord> AnalyzeChords(string fileUrl)
        //{
        //    return this.chordsAnalyzer.Analyzee(fileUrl);
        //}

        public async Task<AudioAnalysis> Analyze(string fileUrl)
        {
            var key = AnalyzeKey(fileUrl);
            var tempo = AnalyzeTempo(fileUrl);
            var chords =AnalyzeChords(fileUrl);
            Task.WaitAll(key, tempo, chords);

            return await GenerateAudioModel(key.Result, tempo.Result, chords.Result);
        }

        
        private async Task<AudioAnalysis> GenerateAudioModel (string key, double tempo, IDictionary<double, string> chords)
        {
            var audioModel = new AudioAnalysis();
            audioModel.Key = key;
            audioModel.Tempo = tempo;
            audioModel.Chords = chords;

            return audioModel;
        }

        private async Task<IDictionary<double, string>> AnalyzeChords(string fileUrl)
        {
            return this.chordsAnalyzer.Analyzee(fileUrl);
        }

        private async Task<double> AnalyzeTempo(string fileUrl)
        {
            return this.tempoAnalyzer.Analyze(fileUrl);
        }

        private async Task<string> AnalyzeKey(string fileUrl)
        {
            return this.keyAnalyzer.Analyze(fileUrl);
        }
    }
}
