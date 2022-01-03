using DTOlayer.Collections.ProductDetail;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IProductDetailService
    {
        List<ProductDetailToGet> GetAll();
        ProductDetailToGet GetProductDetail(int? id);
        void InsertProductDetail(ProductDetailToAdd productDetail);
        void UpdateProductDetail(ProductDetailToUpdate productDetail);
        void DeleteProductDetail(int id);
    }
}
