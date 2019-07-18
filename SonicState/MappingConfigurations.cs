using AutoMapper;
using SonicState.Entities;
using SonicState.Models.BindingModels;
using SonicState.Models.ViewModels;

namespace SonicState.Web
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            //TODO  Fix Audio-AudioDetails mapping
            CreateMap<Audio, AudioDetails>();
            CreateMap<AudioDetails, Audio>();
            CreateMap<ChordUnit, ChordUnitDetails>();
            CreateMap<RegisterUser, User>();
            CreateMap<LoginUser, User>();
           


        }
    }
}
