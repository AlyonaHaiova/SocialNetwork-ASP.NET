using Microsoft.EntityFrameworkCore;
using SocialNetwork.Context;
using SocialNetwork.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Repository.Impl
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public SocialNetworkContext context;
        public DbSet<TEntity> dbSet;

        public GenericRepository(SocialNetworkContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();

        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Remove(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Update(object id)
        {
            TEntity entity = dbSet.Find(id);
            Update(entity);
        }

    }
}
