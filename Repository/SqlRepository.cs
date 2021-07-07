using GenericClassesForPatients.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericClassesForPatients.Repository
{
    public delegate void ItemAdded<T>(T item);
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly Action<T>? _itemAdded;
        private readonly DbSet<T> _dbSet;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList().OrderBy(item => item.Id);
        }
        public void DisplayItems()
        {
            Console.WriteLine("Items will be dispayed");
        }
        public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback =null)
        {
            _dbContext = dbContext;
            _itemAdded = itemAddedCallback;
            _dbSet = _dbContext.Set<T>();
        }
        public event EventHandler<T>? ItemAddedEvent;
        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAdded?.Invoke(item);
            ItemAddedEvent?.Invoke(this, item);
        }
        public void Remove(T item) => _dbSet.Remove(item);

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public T GetItemById(int id)
        {
            return _dbSet.Find(id);
        }

       

      
    }
}
