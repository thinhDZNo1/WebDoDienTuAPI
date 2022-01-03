using AutoMapper;
using DomainLayer.Model;
using DTOLayer.Collections.User;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.UserRepository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public bool CheckUser(string username)
        {
            return repository.CheckUser(username);
        }

        public void DeleteUser(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<UserToGet> GetAll()
        {
            return mapper.Map<List<UserToGet>>(repository.GetAll());
        }

        public UserToGet GetUser(int id)
        {
            return mapper.Map<UserToGet>(repository.Get(id));
        }

        public void InsertUser(UserToAdd user)
        {
            repository.Insert(mapper.Map<User>(user));
        }

        public UserToGet Login(string username, string password)
        {
            return mapper.Map<UserToGet>(repository.Login(username, password));
        }

        public void UpdateUser(UserToUpdate user)
        {
            repository.Update(mapper.Map<User>(user));
        }

    }
}
