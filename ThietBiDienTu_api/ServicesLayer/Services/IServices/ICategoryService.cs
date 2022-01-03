using DTOlayer.Collections.Category;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ICategoryService
    {
        List<CategoryToGet> GetAll();
        CategoryToGet GetCategory(int? id);
        void InsertCategory(CategoryToAdd category);
        void UpdateCategory(CategoryToUpdate category);
        void DeleteCategory(int id);
    }
}
