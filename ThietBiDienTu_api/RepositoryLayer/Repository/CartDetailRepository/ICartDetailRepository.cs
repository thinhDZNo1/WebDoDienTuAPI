using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.CartDetailRepository
{
    public interface ICartDetailRepository: IGenericRepository<CartDetail>
    {
        CartDetail GetCartDetail(int? pdId, int? productId);
        List<CartDetail> GetCartByUser(int? userId);
    }
}
