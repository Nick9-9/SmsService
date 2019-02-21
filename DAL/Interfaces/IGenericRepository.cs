﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create( TEntity entity);
        void Add(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null);
        TEntity GetByID(object id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
        void SaveChanges();
    }
}
