using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Slide;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class SlideService : ISlideService
    {
        private readonly IGenericRepository<Slide> repository;
        private readonly IMapper mapper;
        public SlideService(IGenericRepository<Slide> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteSlide(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<SlideToGet> GetAll()
        {
            return mapper.Map<List<SlideToGet>>(repository.GetAll());
        }

        public SlideToGet GetSlide(int id)
        {
            return mapper.Map<SlideToGet>(repository.Get(id));
        }

        public void InsertSlide(SlideToAdd slide)
        {
            repository.Insert(mapper.Map<Slide>(slide));
        }

        public void UpdateSlide(SlideToUpdate slide)
        {
            repository.Update(mapper.Map<Slide>(slide));
        }

    }
}
