using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Contact;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class ContactService : IContactService
    {
        private readonly IGenericRepository<Contact> repository;
        private readonly IMapper mapper;
        public ContactService(IGenericRepository<Contact> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteContact(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<ContactToGet> GetAll()
        {
            return mapper.Map<List<ContactToGet>>(repository.GetAll());
        }

        public ContactToGet GetContact(int id)
        {
            return mapper.Map<ContactToGet>(repository.Get(id));
        }

        public void InsertContact(ContactToAdd contact)
        {
            repository.Insert(mapper.Map<Contact>(contact));
        }

        public void UpdateContact(ContactToUpdate contact)
        {
            repository.Update(mapper.Map<Contact>(contact));
        }

    }
}
