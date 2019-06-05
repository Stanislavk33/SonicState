using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SonicState.CloudStorage;

namespace SonicState.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        public readonly GoogleCloud googleCloud;

        public AudioController(GoogleCloud googleCloud)
        {
            this.googleCloud = googleCloud;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile audio)
        {
            await googleCloud.Upload(audio);
            return Ok();
        }
    }
}