using SonicState.Entities.Common;

namespace SonicState.Entities
{
    public class Audio : BaseModel<int>
    {
        public Audio() { }

        public string Name { get; set; }

        public double Bpm { get; set; }

        public int KeyId { get; set; }
    }
}
