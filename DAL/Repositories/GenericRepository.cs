using BAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebCustomerApp.Data;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void Dispose()
        {
            context?.Dispose();
        }

        public void Add(TEntity item)
        {
            dbSet.Add(item);
            //context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual IEnumerable<TEntity> GetAll(Func<TEntity, bool> filter = null)
        {
            if (filter != null)
            {
                return dbSet.Where(filter);
            }

            return dbSet.AsEnumerable();
        }
        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            dbSet.Update(item);
            context.SaveChanges();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }

}

