using System.Collections.Generic;

namespace SonicState.SonicAPI.Sonic
{
    internal class SonicTempoAnalyzer : SonicApi
    {
        public double Analyze(string fileUrl)
        {
            var result = base.Analyze<TempoAPIResponse>("analyze/tempo", fileUrl);
            return result.auftakt_result.overall_tempo_straight;
        }
    }

    public class ClickMark
    {
        public int index { get; set; }
        public double bpm { get; set; }
        public double probability { get; set; }
        public double time { get; set; }
        public string downbeat { get; set; }
    }

    public class AuftaktResult
    {
        public int clicks_per_bar { get; set; }
        public double overall_tempo { get; set; }
        public double overall_tempo_straight { get; set; }
        public List<ClickMark> click_marks { get; set; }
    }

    public class TempoAPIResponse
    {
        Status status { get; set; }
        public AuftaktResult auftakt_result { get; set; }
    }
}
