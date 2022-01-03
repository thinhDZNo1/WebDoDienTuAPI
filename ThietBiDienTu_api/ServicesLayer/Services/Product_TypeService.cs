using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Product_Type;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class Product_TypeService : IProduct_TypeService
    {
        private readonly IGenericRepository<Product_Type> repository;
        private readonly IMapper mapper;
        public Product_TypeService(IGenericRepository<Product_Type> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteProduct_Type(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<Product_TypeToGet> GetAll()
        {
            return mapper.Map<List<Product_TypeToGet>>(repository.GetAll());
        }

        public Product_TypeToGet GetProduct_Type(int id)
        {
            return mapper.Map<Product_TypeToGet>(repository.Get(id));
        }

        public void InsertProduct_Type(Product_TypeToAdd Product_Type)
        {
            repository.Insert(mapper.Map<Product_Type>(Product_Type));
        }

        public void UpdateProduct_Type(Product_TypeToUpdate Product_Type)
        {
            repository.Update(mapper.Map<Product_Type>(Product_Type));
        }

    }
}
