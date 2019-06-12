using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Contracts.Repositories
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        IEnumerable<TEntity> All();

        Task Add(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChanges();
    }
}
