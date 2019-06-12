using SonicState.Models.Binding_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Contracts.Services
{
    public interface IAudioService
    {
        Task AddAsync(AudioUpload audio);
    }
}
