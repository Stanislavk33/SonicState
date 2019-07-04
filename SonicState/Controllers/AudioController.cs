using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonicState.Contracts.Services;
using SonicState.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SonicState.Web.Controllers
{
    
    public class AudioController : Controller
    {
        //public readonly FileStorage fileStorage;
        public readonly IAudioService audioService;

        public AudioController (IAudioService audioService) : base()
        {
            this.audioService = audioService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile audio)
        { 
            await audioService.AddAsync(audio);
            return Ok();
        }
        [HttpGet]
        public IEnumerable<AudioDetails> List()
        {
            return audioService.GetAll();
        }
    }
}