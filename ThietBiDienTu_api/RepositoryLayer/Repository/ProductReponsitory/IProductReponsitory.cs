using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.ProductReponsitory
{
    public interface IProductReponsitory : IGenericRepository<Product>
    {
        List<Product> GetListProductSale();
        List<Product> GetProductWithCategory(int? categoryId);
        List<Product> GetProductLikeSame(int? cdId, int? companyId);
        List<Product> SearchProduct(string keyWord);
    }
}
