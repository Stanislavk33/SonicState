using AutoMapper;
using SonicState.Entities;
using SonicState.Models.ViewModels;

namespace SonicState.Web
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Audio, AudioDetails>();
            CreateMap<AudioDetails, Audio>();
        }
    }
}
