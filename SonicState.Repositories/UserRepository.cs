using AutoMapper;
using SonicState.Contracts;
using SonicState.Data;
using SonicState.Entities;
using SonicState.Models.BindingModels;
using SonicState.Models.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SonicState.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        public UserRepository(SonicStateDbContext db, IMapper mapper) : base(db, mapper)
        {

        }

        public async Task Add(RegisterUser user)
        {
            await this.set.AddAsync(this.mapper.Map<User>(user));
            await this.SaveChanges();
        }

        public bool Exists(string userEmail)
        {

            if (this.set.Any(u => u.Email == userEmail))
            {
                return true;
            }
            else { return false; }

        }

        public UserDetails Get(string email)
        {
            var user = this.set.FirstOrDefault(u => u.Email == email);

           return this.mapper.Map<UserDetails>(user);
        }

        public string GetPasswordHash(string userEmail)
        {
            return this.set.FirstOrDefault(u => u.Email == userEmail).Password;
        }
        //public bool IsEmailUnique(string userEmail)
        //{
        //    if (this.set.Any(u => u.Email == userEmail){
        //        return false;
        //    }
        //}
    }
}
