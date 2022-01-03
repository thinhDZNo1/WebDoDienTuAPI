using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.CartDetail;
using RepositoryLayer.Repository;
using RepositoryLayer.Repository.CartDetailRepository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class CartDetailService : ICartDetailService
    {
        private readonly ICartDetailRepository repository;
        private readonly IMapper mapper;
        public CartDetailService(ICartDetailRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteCartDetail(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<CartDetailToGet> GetAll()
        {
            return mapper.Map<List<CartDetailToGet>>(repository.GetAll());
        }

        public List<CartDetailToGet> GetCartByUser(int? userId)
        {
            return mapper.Map<List<CartDetailToGet>>(repository.GetCartByUser(userId));
        }

        public CartDetailToGet GetCartDetail(int? id)
        {
            return mapper.Map<CartDetailToGet>(repository.Get(id));
        }

        public CartDetailToGet GetCartDetail(int? pdId, int? productId)
        {
            return mapper.Map<CartDetailToGet>(repository.GetCartDetail(pdId, productId));
        }

        public void InsertCartDetail(CartDetailToAdd cartDetail)
        {
            repository.Insert(mapper.Map<CartDetail>(cartDetail));
        }

        public void UpdateCartDetail(CartDetailToUpdate cartDetail)
        {
            repository.Update(mapper.Map<CartDetail>(cartDetail));
        }
    }
}
