using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.ProductImages;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ProductImagesService : IProductImagesService
    {
        private readonly IGenericRepository<ProductImages> repository;
        private readonly IMapper mapper;
        public ProductImagesService(IGenericRepository<ProductImages> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteProductImages(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ProductImagesToGet> GetAll()
        {
            return mapper.Map<List<ProductImagesToGet>>(repository.GetAll());
        }

        public ProductImagesToGet GetProductImages(int id)
        {
            return mapper.Map<ProductImagesToGet>(repository.Get(id));
        }

        public void InsertProductImages(ProductImagesToAdd productImages)
        {
            repository.Insert(mapper.Map<ProductImages>(productImages));
        }

        public void UpdateProductImages(ProductImagesToUpdate productImages)
        {
            repository.Update(mapper.Map<ProductImages>(productImages));
        }

    }
}
