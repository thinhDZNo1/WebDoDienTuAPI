using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Product;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.ProductReponsitory;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReponsitory repository;
        private readonly IMapper mapper;
        public ProductService(IProductReponsitory repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteProduct(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ProductToGet> GetAll()
        {
            return mapper.Map<List<ProductToGet>>(repository.GetAll());
        }

        public List<ProductToGet> GetListProductSale()
        {
            return mapper.Map<List<ProductToGet>>(repository.GetListProductSale());
        }

        public ProductToGet GetProduct(int? id)
        {
            return mapper.Map<ProductToGet>(repository.Get(id));
        }

        public List<ProductToGet> GetProductLikeSame(int? cdId, int? companyId)
        {
            return mapper.Map<List<ProductToGet>>(repository.GetProductLikeSame(cdId, companyId));
        }

        public List<ProductToGet> GetProductWithCategory(int? categoryId)
        {
            return mapper.Map<List<ProductToGet>>(repository.GetProductWithCategory(categoryId));
        }

        public void InsertProduct(ProductToAdd product)
        {
            repository.Insert(mapper.Map<Product>(product));
        }

        public List<ProductToGet> SearchProduct(string keyWord)
        {
            return mapper.Map<List<ProductToGet>>(repository.SearchProduct(keyWord));
        }

        public void UpdateProduct(ProductToUpdate product)
        {
            repository.Update(mapper.Map<Product>(product));
        }
    }
}
