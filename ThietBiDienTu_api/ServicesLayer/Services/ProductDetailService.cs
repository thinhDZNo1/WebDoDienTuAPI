using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.ProductDetail;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IGenericRepository<ProductDetail> repository;
        private readonly IMapper mapper;
        public ProductDetailService(IGenericRepository<ProductDetail> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteProductDetail(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ProductDetailToGet> GetAll()
        {
            return mapper.Map<List<ProductDetailToGet>>(repository.GetAll());
        }

        public ProductDetailToGet GetProductDetail(int? id)
        {
            return mapper.Map<ProductDetailToGet>(repository.Get(id));
        }

        public void InsertProductDetail(ProductDetailToAdd productDetail)
        {
            repository.Insert(mapper.Map<ProductDetail>(productDetail));
        }

        public void UpdateProductDetail(ProductDetailToUpdate productDetail)
        {
            repository.Update(mapper.Map<ProductDetail>(productDetail));
        }

    }
}
