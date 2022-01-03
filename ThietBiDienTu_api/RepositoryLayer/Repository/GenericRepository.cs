using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        private readonly ThietBiDienTuDBContext db;
        private DbSet<T> entities;
        public GenericRepository(ThietBiDienTuDBContext db)
        {
            this.db = db;
            entities = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int? id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Update(entity);
            db.Update(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            db.Update(entity);
        }

        public void Remove(int id)
        {
            T entity = entities.SingleOrDefault(x => x.Id == id);
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

    }
}
