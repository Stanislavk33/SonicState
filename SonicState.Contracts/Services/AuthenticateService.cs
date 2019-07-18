using SonicState.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Contracts.Services
{
   public interface AuthenticateService
    {
        bool IsAuthenticated(LoginUser user, out string token);
    }
}
