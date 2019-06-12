using AutoMapper;
using SonicState.Contracts.Repositories;
using SonicState.Contracts.Services;
using SonicState.Entities;
using SonicState.Models.Binding_Models;
using System;
using System.Threading.Tasks;

namespace SonicState.Services
{
    public class AudioService : IAudioService
    {
        private readonly IAudioRepository audioRepository;
        private readonly IMapper mapper;
        
        public AudioService
            (IAudioRepository audioRepository,IMapper mapper)
        {
            this.audioRepository = audioRepository;
            this.mapper = mapper;
        }

        public async Task AddAsync(AudioUpload audio)
        {
            var newAudio = mapper.Map<Audio>(audio);
            newAudio.Name = audio.Name;

            await audioRepository.Add(newAudio);
            await audioRepository.SaveChanges();
        }

    }
}
