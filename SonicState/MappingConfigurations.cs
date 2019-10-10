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

            CreateMap<Audio, AudioDetails>()
            .ForMember(ad => ad.FileName, src => src.MapFrom(a => a.Name));

            CreateMap<AudioDetails, Audio>();
            CreateMap<ChordUnit, ChordUnitDetails>();
            CreateMap<RegisterUser, User>();
            CreateMap<LoginUser, User>();
            CreateMap<User, UserDetails>();
           


        }
    }
}
