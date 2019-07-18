using AutoMapper;
using SonicState.Contracts;
using SonicState.Data;
using SonicState.Entities;
using SonicState.Models.BindingModels;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        public UserRepository(SonicStateDbContext db, IMapper mapper) : base(db, mapper)
        {
            
        }
        
        public async Task Add (RegisterUser user)
        {
           await this.set.AddAsync(this.mapper.Map<User> (user));
           await this.SaveChanges();
        }

        public bool Exists (string userEmail)
        {
           
            if (this.set.Any(u => u.Email == userEmail))
            {
                return true;
            }
            else { return false; }
            
        }

    }
}
