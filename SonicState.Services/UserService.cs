using SonicState.Contracts;
using SonicState.Contracts.Services;
using SonicState.Models.BindingModels;
using System.Threading.Tasks;

namespace SonicState.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordService passwordService;

        public UserService
            (IUserRepository userRepository, IPasswordService passwordService)
        {
            this.passwordService = passwordService;
            this.userRepository = userRepository;
        }
        public Task Add(RegisterUser user)
        {
           user.Password = passwordService.CreateHash(user.Password);
           return userRepository.Add(user);
        }


    }
}
