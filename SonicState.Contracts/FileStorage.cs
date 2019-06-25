using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SonicState.Contracts
{
    public interface FileStorage
    {
        Task Upload(IFormFile file);

        Task<string> GenerateURL(string objectName);
    }
}
