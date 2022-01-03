using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Cart;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class CartService : ICartService
    {
        private readonly IGenericRepository<Cart> repository;
        private readonly IMapper mapper;
        public CartService(IGenericRepository<Cart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteCart(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<CartToGet> GetAll()
        {
            return mapper.Map<List<CartToGet>>(repository.GetAll());
        }

        public CartToGet GetCart(int? id)
        {
            return mapper.Map<CartToGet>(repository.Get(id));
        }

        public void InsertCart(CartToAdd cart)
        {
            repository.Insert(mapper.Map<Cart>(cart));
        }

        public void UpdateCart(CartToUpdate cart)
        {
            repository.Update(mapper.Map<Cart>(cart));
        }

    }
}
