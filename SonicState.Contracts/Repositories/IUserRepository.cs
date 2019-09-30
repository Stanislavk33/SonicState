using SonicState.Contracts.Repositories;
using SonicState.Entities;
using SonicState.Models.BindingModels;
using System.Threading.Tasks;

namespace SonicState.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
         Task Add(RegisterUser user);

         bool Exists(string userEmail);

        string GetPasswordHash(string userEmail);
    }
}