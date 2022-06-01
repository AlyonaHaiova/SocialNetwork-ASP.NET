using System;
using System.Collections.Generic;

namespace SocialNetwork.Repository.Abstract
{

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Insert(TEntity item);
        void Remove(TEntity item);
        void Remove(object id);
        void Update(TEntity item);
        void Update(object id);
    }
}