using DTOlayer.Collections.CategoryDetail;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ICategoryDetailService
    {
        List<CategoryDetailToGet> GetAll();
        CategoryDetailToGet GetCategoryDetail(int? id);
        void InsertCategoryDetail(CategoryDetailToAdd categoryDetail);
        void UpdateCategoryDetail(CategoryDetailToUpdate categoryDetail);
        void DeleteCategoryDetail(int id);
    }
}
