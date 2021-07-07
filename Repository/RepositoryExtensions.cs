using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesForPatients.Repository
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IWriteRepository<T> Repository, T[] items)
        {
            foreach (var item in items)
            {
                Repository.Add(item);
            }
            Repository.Save();
        }
    }
}
