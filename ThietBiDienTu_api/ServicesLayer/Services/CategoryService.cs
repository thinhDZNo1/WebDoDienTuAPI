using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Category;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> repository;
        private readonly IMapper mapper;
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteCategory(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<CategoryToGet> GetAll()
        {
            return mapper.Map<List<CategoryToGet>>(repository.GetAll());
        }

        public CategoryToGet GetCategory(int? id)
        {
            return mapper.Map<CategoryToGet>(repository.Get(id));
        }

        public void InsertCategory(CategoryToAdd category)
        {
            repository.Insert(mapper.Map<Category>(category));
        }

        public void UpdateCategory(CategoryToUpdate category)
        {
            repository.Update(mapper.Map<Category>(category));
        }

    }
}
