using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.ConfirmOrder;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ConfirmOrderService : IConfirmOrderService
    {
        private readonly IGenericRepository<ConfirmOrder> repository;
        private readonly IMapper mapper;
        public ConfirmOrderService(IGenericRepository<ConfirmOrder> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteConfirmOrder(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ConfirmOrderToGet> GetAll()
        {
            return mapper.Map<List<ConfirmOrderToGet>>(repository.GetAll());
        }

        public ConfirmOrderToGet GetConfirmOrder(int id)
        {
            return mapper.Map<ConfirmOrderToGet>(repository.Get(id));
        }

        public void InsertConfirmOrder(ConfirmOrderToAdd confirmOrder)
        {
            repository.Insert(mapper.Map<ConfirmOrder>(confirmOrder));
        }

        public void UpdateConfirmOrder(ConfirmOrderToUpdate confirmOrder)
        {
            repository.Update(mapper.Map<ConfirmOrder>(confirmOrder));
        }

    }
}
