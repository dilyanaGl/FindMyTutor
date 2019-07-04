using FindMyTutor.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FindMyTutor.Data
{
    public class DbRepository<TEntity> : IDisposable, IRepository<TEntity> 
        where TEntity : class
    {
        private readonly FindMyTutorWebContext context;
        private readonly DbSet<TEntity> dbSet;

        public DbRepository(FindMyTutorWebContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
            
        }

        public async Task Add(TEntity entity)
        {
            await this.dbSet.AddAsync(entity);           
            
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Dispose()
        {
            context.Dispose();
        }



        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
            
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync();
        }

        
    }
}
