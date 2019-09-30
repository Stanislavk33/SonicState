using FluentValidation;
using SonicState.Contracts;
using SonicState.Contracts.Services;
using SonicState.Models.BindingModels;

namespace SonicState.Validations.ValidationRules
{
    public class LoginUserValidationRules : AbstractValidator<LoginUser>
    {
        private readonly IPasswordService passwordService;
        private readonly IUserRepository userRepository;
        public LoginUserValidationRules(
             IPasswordService passwordService, IUserRepository userRepository)
        {
            this.passwordService = passwordService;
            this.userRepository = userRepository;

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(Email => CheckIfEmailExists(Email)).WithMessage("There is no user with this email");

            When(u => CheckIfEmailExists(u.Email) == true, () =>
            {
             RuleFor(u => u.Password)
                .NotEmpty()
                .Must((u, Password) => VerifyPassword(u.Email, Password)).WithMessage("Password doesn't match");
            });
                
        }

        private bool VerifyPassword(string email, string password)
        {
            var passwordHash = userRepository.GetPasswordHash(email);
            if (passwordService.VerifyPassword(password, passwordHash)) return true;
            return false;
        }

        private bool CheckIfEmailExists(string email)
        {
            if (userRepository.Exists(email)) { return true; }
            return false;
        }
    }
}
