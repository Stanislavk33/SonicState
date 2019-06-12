﻿using Microsoft.EntityFrameworkCore;
using SonicState.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SonicState.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable 
        where TEntity : class
    {
        private readonly SonicStateDbContext context;
        protected DbSet<TEntity> set;

        public DbRepository(SonicStateDbContext context)
        {
            this.context = context;
            this.set = this.context.Set<TEntity>();
        }

        public Task Add(TEntity entity)
        {
            return this.set.AddAsync(entity);
        }

        public IEnumerable<TEntity> All()
        {
            return this.set;
        }

        public void Delete(TEntity entity)
        {
            this.set.Remove(entity);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task<int> SaveChanges()
        {
            return this.context.SaveChangesAsync();
        }
    }
}