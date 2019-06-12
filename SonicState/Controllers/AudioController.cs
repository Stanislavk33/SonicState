using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonicState.CloudStorage;
using SonicState.Contracts;
using SonicState.Contracts.Services;
using SonicState.Models.Binding_Models;
using SonicState.Services;

namespace SonicState.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        public readonly FileStorage fileStorage;
        public readonly IAudioService audioService;

        public AudioController(FileStorage fileStorage, IAudioService audioService)
        {
            this.fileStorage = fileStorage;
            this.audioService = audioService;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile audio)
        { 
            await fileStorage.Upload(audio);
            var newAudio = new AudioUpload();
            newAudio.Name = audio.FileName;
            await audioService.AddAsync(newAudio);
            return Ok();
        }
    }
}