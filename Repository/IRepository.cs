using GenericClassesForPatients.Entity;
using System.Collections.Generic;

namespace GenericClassesForPatients.Repository
{
    public interface IRepository<T>:IReadRepository<T>, IWriteRepository<T> where T : IEntity
    {  
    }
    public interface IReadRepository <out T>
    {
        IEnumerable<T> GetAll();
        T GetItemById(int id);
        void DisplayItems();
    }
    public interface IWriteRepository <in T>
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }

}