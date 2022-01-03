using DTOlayer.Collections.ProductReview;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IProductReviewService
    {
        List<ProductReviewToGet> GetAll();
        ProductReviewToGet GetProductReview(int id);
        void InsertProductReview(ProductReviewToAdd productReview);
        void UpdateProductReview(ProductReviewToUpdate productReview);
        void DeleteProductReview(int id);
    }
}
