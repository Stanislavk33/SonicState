using Microsoft.AspNetCore.Http;
using SonicState.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonicState.Contracts.Services
{
    public interface IAudioService
    {
        Task AddAsync(IFormFile audio);
        IEnumerable<AudioDetails> GetAll();
    }
}
