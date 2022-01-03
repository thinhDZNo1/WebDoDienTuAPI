using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Menu;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<Menu> repository;
        private readonly IMapper mapper;
        public MenuService(IGenericRepository<Menu> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteMenu(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<MenuToGet> GetAll()
        {
            return mapper.Map<List<MenuToGet>>(repository.GetAll());
        }

        public MenuToGet GetMenu(int id)
        {
            return mapper.Map<MenuToGet>(repository.Get(id));
        }

        public void InsertMenu(MenuToAdd menu)
        {
            repository.Insert(mapper.Map<Menu>(menu));
        }

        public void UpdateMenu(MenuToUpdate menu)
        {
            repository.Update(mapper.Map<Menu>(menu));
        }

    }
}
