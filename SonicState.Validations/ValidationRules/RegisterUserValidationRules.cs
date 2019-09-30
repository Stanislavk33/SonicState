using FluentValidation;
using SonicState.Contracts;
using SonicState.Models.BindingModels;

namespace SonicState.Validations.ValidationRules
{
    public class RegisterUserValidationRules : AbstractValidator<RegisterUser>
    {
        private readonly IUserRepository userRepository;

        public RegisterUserValidationRules(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Please specify a email")
                .EmailAddress()
                .Must(Email => IsEmailUnique(Email)).WithMessage("The email is already in use");

           
            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Please enter a password with minimum 8 characters");

        }

        private bool IsEmailUnique(string email)
        {
            if (userRepository.Exists(email)) { return false; }
            return true;
        }
    }
}
