using SonicState.Contracts.Repositories;
using SonicState.Entities;
using SonicState.Models.BindingModels;
using SonicState.Models.ViewModels;
using System.Threading.Tasks;

namespace SonicState.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
         Task Add(RegisterUser user);

        UserDetails Get(string email);

         bool Exists(string userEmail);

        string GetPasswordHash(string userEmail);
    }
}