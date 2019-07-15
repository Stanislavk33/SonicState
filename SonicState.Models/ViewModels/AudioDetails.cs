﻿using SonicState.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Models.ViewModels
{
    public class AudioDetails
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Bpm { get; set; }
        public string Key { get; set; }
        public string StorageName { get; set; }
    }
}