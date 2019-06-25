using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonicState.Contracts.Services;
using System.Threading.Tasks;

namespace SonicState.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        //public readonly FileStorage fileStorage;
        public readonly IAudioService audioService;

        public AudioController (IAudioService audioService)
        {
            this.audioService = audioService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile audio)
        { 
            await audioService.AddAsync(audio);
            return Ok();
        }
    }
}