using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int? id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(int id);
        void SaveChanges();
    }
}
