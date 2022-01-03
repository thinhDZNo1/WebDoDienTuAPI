using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Message;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IGenericRepository<Message> repository;
        private readonly IMapper mapper;
        public MessageService(IGenericRepository<Message> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteMessage(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<MessageToGet> GetAll()
        {
            return mapper.Map<List<MessageToGet>>(repository.GetAll());
        }

        public MessageToGet GetMessage(int id)
        {
            return mapper.Map<MessageToGet>(repository.Get(id));
        }

        public void InsertMessage(MessageToAdd message)
        {
            repository.Insert(mapper.Map<Message>(message));
        }

        public void UpdateMessage(MessageToUpdate message)
        {
            repository.Update(mapper.Map<Message>(message));
        }

    }
}
