using SonicState.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Models.ViewModels
{
    public class AudioDetails
    {
        public AudioDetails()
        {
        }
        public string Id { get; set; }
        public string FileName { get; set; }
        public double Bpm { get; set; }
        public string Key { get; set; }

        public string Format => FileName.Split(".")[1];

        public string Name => FileName.Split(".")[0];
    }
}
