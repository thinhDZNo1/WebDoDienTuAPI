using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.CategoryDetail;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class CategoryDetailService : ICategoryDetailService
    {
        private readonly IGenericRepository<CategoryDetail> repository;
        private readonly IMapper mapper;
        public CategoryDetailService(IGenericRepository<CategoryDetail> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteCategoryDetail(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<CategoryDetailToGet> GetAll()
        {
            return mapper.Map<List<CategoryDetailToGet>>(repository.GetAll());
        }

        public CategoryDetailToGet GetCategoryDetail(int? id)
        {
            return mapper.Map<CategoryDetailToGet>(repository.Get(id));
        }

        public void InsertCategoryDetail(CategoryDetailToAdd categoryDetail)
        {
            repository.Insert(mapper.Map<CategoryDetail>(categoryDetail));
        }

        public void UpdateCategoryDetail(CategoryDetailToUpdate categoryDetail)
        {
            repository.Update(mapper.Map<CategoryDetail>(categoryDetail));
        }

    }
}
