using GenericClassesForPatients.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericClassesForPatients.Repository
{
    public class ItemRepository<T> :IRepository<T> where T : IEntity
    {
        private readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public void Add(T item)
        {
            item.Id = _items.Any()?_items.Count+1:1;
            _items.Add(item);
        }
        public void Remove(T item) => _items.Remove(item);
        public void DisplayItems()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
        public T GetItemById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Save()
        {
            Console.WriteLine("Your entry was saved");
        }

       
    }
}
