using SonicState.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Contracts
{
    public interface AudioAnalyzer
    {
        Task<AudioAnalysis> Analyze(string fileUrl);
    }
}
