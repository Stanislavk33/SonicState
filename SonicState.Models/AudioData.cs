using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Models
{
    public class AudioAnalysis
    {
        public string Key { get; set; }
        public double Tempo  { get; set; }
        public IDictionary<double,string> Chords { get; set; }
    }

}
