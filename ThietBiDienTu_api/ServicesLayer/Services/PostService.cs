using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections;
using DTOlayer.Collections.Post;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> repository;
        private readonly IMapper mapper;
        public PostService(IGenericRepository<Post> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeletePost(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<PostToGet> GetAll()
        {
            return mapper.Map<List<PostToGet>>(repository.GetAll());
        }

        public PostToGet GetPost(int id)
        {
            return mapper.Map<PostToGet>(repository.Get(id));
        }

        public void InsertPost(PostToAdd post)
        {
            repository.Insert(mapper.Map<Post>(post));
        }

        public void UpdatePost(PostToUpdate post)
        {
            repository.Update(mapper.Map<Post>(post));
        }

    }
}
