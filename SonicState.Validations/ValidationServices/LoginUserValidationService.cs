using FluentValidation;
using SonicState.Contracts.Services.ValidationServices;
using SonicState.Models.BindingModels;
using SonicState.Validations.ValidationRules;


namespace SonicState.Validations.ValidationServices
{
    public class LoginUserValidationService : ILoginUserValidationService
    {
        private readonly LoginUserValidationRules loginUserValidationRules;

        public LoginUserValidationService(
            LoginUserValidationRules loginUserValidationRules)
        {
            this.loginUserValidationRules = loginUserValidationRules;
        }

        public ILoginUserValidationService Validate (LoginUser loginUser)
        {
            var validationResult = loginUserValidationRules.Validate(loginUser);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            return this;
        }
    }
}
