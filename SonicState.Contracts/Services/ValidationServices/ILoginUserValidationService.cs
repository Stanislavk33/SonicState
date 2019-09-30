using SonicState.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicState.Contracts.Services.ValidationServices
{
    public interface ILoginUserValidationService
    {
        ILoginUserValidationService Validate(LoginUser loginUser);
    }
}
