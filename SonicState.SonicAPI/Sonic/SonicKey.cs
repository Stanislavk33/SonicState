namespace SonicState.SonicAPI.Sonic
{
    internal class SonicKeyAnalyzer : SonicApi
    {
        public string Analyze(string fileUrl)
        {
            var result = base.Analyze<KeyAPIResponse>("analyze/key", fileUrl);
            return result.tonart_result.key;
        }
    }


    public class TonartResult
    {
        public string key { get; set; }
        public double tuning_frequency { get; set; }
    }

    public class KeyAPIResponse
    {
        Status status { get; set; }
        public TonartResult tonart_result { get; set; }
    }
}
