using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SonicState.Contracts.Services
{
    public interface IAudioService
    {
        Task AddAsync(IFormFile audio);
    }
}
