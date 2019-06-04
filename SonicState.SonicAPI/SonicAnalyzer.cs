using SonicState.SonicAPI.Sonic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.SonicAPI
{
    public class SonicAnalyzer
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

        public IDictionary<double, string> AnalyzeChords(string fileUrl)
        {
            return this.chordsAnalyzer.Analyzee(fileUrl);
        }
        public double AnalyzeTempo(string fileUrl)
        {
            return this.tempoAnalyzer.Analyze(fileUrl);
        }

        public string AnalyzeKey(string fileUrl)
        {
            return this.keyAnalyzer.Analyze(fileUrl);
        }
    }
}
