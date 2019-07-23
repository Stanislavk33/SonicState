using FluentValidation;
using SonicState.Contracts;
using SonicState.Contracts.ValidationRules;
using SonicState.Models.BindingModels;



namespace SonicState.Validations.ValidationRules
{
    public class RegisterUserValidationRules : AbstractValidator<RegisterUser>, IRegisterUserValidationRules
    {
        private readonly IUserRepository userRepository;

        public RegisterUserValidationRules(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Please specify a email")
                .EmailAddress()
               .Must(Email => IsEmailUnique(Email)).WithMessage("The email is already in use");

            //.Must(u => u.Equals(userRepository.Exists())).WithMessage("There is a registered user with this email");
          //  RuleFor(u => u.Email).Must(email => IsEmailUnique(email));
                RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Please enter a password with minimum 8 characters");
            
        }

        private bool IsEmailUnique (string email)
        {
            if (userRepository.Exists(email)) { return false; }
            return true;
        }
    }
}
