﻿using Microsoft.EntityFrameworkCore;
using StockExchange.Infrastructure.Data;
using StockExchange.Infrastructure.IRepositories;

namespace StockExchange.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return table;
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            if (existing != null)
                table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public T GetByIdAsNoTracking(object id)
        {
            var entity = table.Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
    }
}
