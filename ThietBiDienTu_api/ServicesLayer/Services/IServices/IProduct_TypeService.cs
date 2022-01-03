using DTOlayer.Collections.Product_Type;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IProduct_TypeService
    {
        List<Product_TypeToGet> GetAll();
        Product_TypeToGet GetProduct_Type(int id);
        void InsertProduct_Type(Product_TypeToAdd product_Type);
        void UpdateProduct_Type(Product_TypeToUpdate product_Type);
        void DeleteProduct_Type(int id);
    }
}
