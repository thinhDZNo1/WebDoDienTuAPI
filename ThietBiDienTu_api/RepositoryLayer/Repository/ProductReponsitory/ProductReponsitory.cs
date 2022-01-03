using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.ProductReponsitory
{
    public class ProductReponsitory : GenericRepository<Product>, IProductReponsitory
    {
        private readonly ThietBiDienTuDBContext db;
        public ProductReponsitory(ThietBiDienTuDBContext db): base(db)
        {
            this.db = db;
        }

        public List<Product> GetListProductSale()
        {
            List<Product> products = db.Product.Where(x => x.Discount != 0).Take(10).ToList();
            return products;
        }

        public List<Product> GetProductLikeSame(int? cdId, int? companyId)
        {
            List<Product> list = db.Product.Where(x => x.CategoryDetailId.Equals(cdId) || x.CompanyId.Equals(companyId)).Take(10).ToList();
            return list;
        }

        public List<Product> GetProductWithCategory(int? categoryId)
        {
            List<Product> list = (from p in db.Product
                                join cd in db.CategoryDetail on p.CategoryDetailId equals cd.Id
                                join c in db.Category on cd.CategoryId equals c.Id
                                where c.Id == categoryId
                                select p).ToList();
            return list;
        }

        public List<Product> SearchProduct(string keyWord)
        {
            List<Product> list = (from p in db.Product where p.Name.ToLower().Contains(keyWord.ToLower()) select p).ToList();
            return list;
        }
    }
}
