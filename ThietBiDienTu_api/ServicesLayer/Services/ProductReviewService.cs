using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.ProductReview;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ProductReviewService : IProductReviewService
    {
        private readonly IGenericRepository<ProductReview> repository;
        private readonly IMapper mapper;
        public ProductReviewService(IGenericRepository<ProductReview> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteProductReview(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ProductReviewToGet> GetAll()
        {
            return mapper.Map<List<ProductReviewToGet>>(repository.GetAll());
        }

        public ProductReviewToGet GetProductReview(int id)
        {
            return mapper.Map<ProductReviewToGet>(repository.Get(id));
        }

        public void InsertProductReview(ProductReviewToAdd productReview)
        {
            repository.Insert(mapper.Map<ProductReview>(productReview));
        }

        public void UpdateProductReview(ProductReviewToUpdate productReview)
        {
            repository.Update(mapper.Map<ProductReview>(productReview));
        }

    }
}
