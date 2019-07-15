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
        public readonly IChordService chordService;


        public AudioController 
            (IAudioService audioService, IChordService chordService) : base()
        {
            this.audioService = audioService;
            this.chordService = chordService;
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
        
        public ICollection<ChordUnitDetails> SongTutorial(string id)
        {
            return chordService.GetChordSequence(id);
        }
    }
}