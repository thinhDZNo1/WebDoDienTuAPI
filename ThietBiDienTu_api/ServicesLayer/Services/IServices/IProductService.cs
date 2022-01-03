using DTOlayer.Collections.Product;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IProductService
    {
        List<ProductToGet> GetAll();
        ProductToGet GetProduct(int? id);
        void InsertProduct(ProductToAdd product);
        void UpdateProduct(ProductToUpdate product);
        void DeleteProduct(int id);
        List<ProductToGet> GetListProductSale();
        List<ProductToGet> GetProductWithCategory(int? categoryId);
        List<ProductToGet> GetProductLikeSame(int? cdId, int? companyId);
        List<ProductToGet> SearchProduct(string keyWord);
    }
}
