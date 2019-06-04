using System.Collections.Generic;
using System.Linq;

namespace SonicState.SonicAPI.Sonic
{
    internal class SonicChordsAnalyzer : SonicApi
    {
        public IEnumerable<Chord> Analyze(string fileUrl)
        {
            var result = base.Analyze<ChordsAPIResponse>("analyze/chords", fileUrl);
            return result.chords_result.chords;
        }

        public IDictionary<double, string> Analyzee(string fileUrl)
        {
            var result = base.Analyze<ChordsAPIResponse>("analyze/chords", fileUrl);
            var chordList = result.chords_result.chords;
            return chordList.Select(c => new { c.time, c.chord }).ToDictionary(x => x.time, x => x.chord);

        }
    }

    internal class ChordsAPIResponse
    {
        public Status status { get; set; }
        public ChordsResult chords_result { get; set; }
    }

    internal class Status
    {
        public int code { get; set; }
    }

    internal class ChordsResult
    {
        public int num_chords { get; set; }
        public List<Chord> chords { get; set; }
    }

    public class Chord
    {
        public int index { get; set; }
        public double time { get; set; }
        public string chord { get; set; }
    }
}
