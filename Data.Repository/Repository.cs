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

        protected IEnumerable<T> BaseRepository_GetPage(Expression<Func<T, long>> orderbyExpression, int currentPage,
            int pageSize, out int totalCount)
        {
            return BaseRepositoryGetPage(orderbyExpression, currentPage, pageSize, out totalCount);
        }

        protected IEnumerable<T> BaseRepository_GetPage(Expression<Func<T, long>> orderbyExpression,
            Expression<Func<T, bool>> expression, int currentPage, int pageSize, out int totalCount)
        {
            totalCount = _dbSet.Count(expression);
            return
                _dbSet.Where(expression).OrderByDescending(expression)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);
        }

        private IEnumerable<T> BaseRepositoryGetPage(Expression<Func<T, long>> orderbyExpression, int currentPage,
            int pageSize, out int totalCount)
        {
            totalCount = _dbSet.Count();
            return
                _dbSet.OrderByDescending(orderbyExpression)
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);
        }
    }
}
