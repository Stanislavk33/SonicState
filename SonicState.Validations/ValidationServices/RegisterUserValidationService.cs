using FluentValidation;
using SonicState.Contracts.Services.ValidationServices;
using SonicState.Models.BindingModels;
using SonicState.Validations.ValidationRules;

namespace SonicState.Validations.ValidationServices
{
    public class RegisterUserValidationService : IRegisterUserValidationService
    {
        private readonly RegisterUserValidationRules registerUserValidationRules;

        public RegisterUserValidationService(
            RegisterUserValidationRules registerUserValidationRules)
        {
            this.registerUserValidationRules = registerUserValidationRules;
        }

        public IRegisterUserValidationService Validate(RegisterUser registerUser)
        {
            var validationResult = registerUserValidationRules.Validate(registerUser);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return this;
        }
    }
}

