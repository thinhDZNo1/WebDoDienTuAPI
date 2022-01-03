using DTOlayer.Collections.Cart;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ICartService
    {
        List<CartToGet> GetAll();
        CartToGet GetCart(int? id);
        void InsertCart(CartToAdd cart);
        void UpdateCart(CartToUpdate cart);
        void DeleteCart(int id);
    }
}
