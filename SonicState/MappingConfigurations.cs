using AutoMapper;
using SonicState.Entities;
using SonicState.Models.Binding_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Web
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<AudioUpload,Audio>();
        }
    }
}
