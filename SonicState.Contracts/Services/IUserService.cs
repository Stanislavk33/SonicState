using SonicState.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Contracts.Services
{
    public interface IUserService
    {
        Task Add(RegisterUser user);
    }
}
