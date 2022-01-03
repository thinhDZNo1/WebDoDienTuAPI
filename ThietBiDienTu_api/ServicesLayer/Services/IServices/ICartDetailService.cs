using DTOlayer.Collections.CartDetail;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ICartDetailService
    {
        List<CartDetailToGet> GetAll();
        CartDetailToGet GetCartDetail(int? id);
        void InsertCartDetail(CartDetailToAdd cart);
        void UpdateCartDetail(CartDetailToUpdate cart);
        void DeleteCartDetail(int id);
        CartDetailToGet GetCartDetail(int? pdId, int? productId);
        List<CartDetailToGet> GetCartByUser(int? userId);
    }
}
