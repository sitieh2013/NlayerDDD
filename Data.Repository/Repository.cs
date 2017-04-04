using Data.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class Repository<T> where T : Entity
    {
        private readonly DbContext _contexto;
        private readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _contexto = context;
            _dbSet = _contexto.Set<T>();
        }

        protected Repository()
        {
            _contexto = new DataBaseContext();
            _dbSet = _contexto.Set<T>();
        }

        protected void Repository_Insert(T entidad)
        {
            _dbSet.Add(entidad);
            _contexto.Entry(entidad).State = EntityState.Added;
            _contexto.SaveChanges();
        }

        protected void Repository_Delete(T entidad)
        {
            _dbSet.Remove(entidad);
            _contexto.Entry(entidad).State = EntityState.Deleted;
            _contexto.SaveChanges();
        }

        protected IEnumerable<T> Repository_Find(Expression<Func<T, bool>> expresion)
        {
            return _dbSet.Where(expresion);
        }

        protected T Repository_FindById(long id)
        {
            return _dbSet.Find(id);
        }

        protected IEnumerable<T> Repository_FindAll()
        {
            return _dbSet;
        }

        protected void Repository_Saves(T entidad)
        {
            var entry = _contexto.Entry(entidad);
            entry.State = EntityState.Modified;
            _contexto.SaveChanges();
        }
    }
}
