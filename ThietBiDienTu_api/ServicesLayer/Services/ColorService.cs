using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Color;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ColorService : IColorService
    {
        private readonly IGenericRepository<Color> repository;
        private readonly IMapper mapper;
        public ColorService(IGenericRepository<Color> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteColor(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ColorToGet> GetAll()
        {
            return mapper.Map<List<ColorToGet>>(repository.GetAll());
        }

        public ColorToGet GetColor(int id)
        {
            return mapper.Map<ColorToGet>(repository.Get(id));
        }

        public void InsertColor(ColorToAdd color)
        {
            repository.Insert(mapper.Map<Color>(color));
        }

        public void UpdateColor(ColorToUpdate color)
        {
            repository.Update(mapper.Map<Color>(color));
        }

    }
}
