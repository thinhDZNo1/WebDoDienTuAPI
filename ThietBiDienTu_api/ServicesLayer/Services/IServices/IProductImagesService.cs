using DTOlayer.Collections.ProductImages;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IProductImagesService
    {
        List<ProductImagesToGet> GetAll();
        ProductImagesToGet GetProductImages(int id);
        void InsertProductImages(ProductImagesToAdd productImages);
        void UpdateProductImages(ProductImagesToUpdate productImages);
        void DeleteProductImages(int id);
    }
}
