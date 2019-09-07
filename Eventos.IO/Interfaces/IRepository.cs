using Eventos.IO.Domain.Core.Eventos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(Guid Id);
        IEnumerable GetAll();
        void Update(TEntity obj);
        void Remove(Guid Id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
