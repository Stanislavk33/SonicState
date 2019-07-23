using SonicState.Contracts;
using SonicState.Contracts.Services;
using SonicState.Contracts.Services.ValidationServices;
using SonicState.Models.BindingModels;
using System.Threading.Tasks;

namespace SonicState.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordService passwordService;
        private readonly IRegisterUserValidationService registerUserValidationService;

        public UserService
            (IUserRepository userRepository, IPasswordService passwordService, IRegisterUserValidationService registerUserValidationService)
        {
            this.passwordService = passwordService;
            this.userRepository = userRepository;
            this.registerUserValidationService = registerUserValidationService;
        }
        public Task Add(RegisterUser user)
        {
           registerUserValidationService.Validate(user);
           user.Password = passwordService.CreateHash(user.Password);
           return userRepository.Add(user);
        }

        
    }
}
