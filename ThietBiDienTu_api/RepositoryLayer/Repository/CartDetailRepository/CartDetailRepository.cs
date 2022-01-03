using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.CartDetailRepository
{
    public class CartDetailRepository: GenericRepository<CartDetail>, ICartDetailRepository
    {
        private readonly ThietBiDienTuDBContext db;
        public CartDetailRepository(ThietBiDienTuDBContext db): base(db)
        {
            this.db = db;
        }

        public List<CartDetail> GetCartByUser(int? userId)
        {
            List<CartDetail> list = (from cd in db.CartDetail
                                     join c in db.Cart on cd.CartId equals c.Id
                                     where c.UserId == userId
                                     select cd).ToList();
            return list;
        }

        public CartDetail GetCartDetail(int? pdId, int? productId)
        {
            return db.CartDetail.FirstOrDefault(x => x.PDId.Equals(pdId) || x.ProductId.Equals(productId));
        }
    }
}
