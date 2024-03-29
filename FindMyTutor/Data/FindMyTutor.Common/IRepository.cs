﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FindMyTutor.Common
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();

        Task<int> Add(TEntity entity);

        void Remove(TEntity entity);

        Task<int> SaveChangesAsync();    



        
    }
}
