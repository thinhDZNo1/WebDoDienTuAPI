using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.Company;
using RepositoryLayer.Repository;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;

namespace ServicesLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> repository;
        private readonly IMapper mapper;
        public CompanyService(IGenericRepository<Company> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public void DeleteCompany(int id)
        {
            repository.Remove(id);
            repository.SaveChanges();
        }

        public List<CompanyToGet> GetAll()
        {
            return mapper.Map<List<CompanyToGet>>(repository.GetAll());
        }

        public CompanyToGet GetCompany(int? id)
        {
            return mapper.Map<CompanyToGet>(repository.Get(id));
        }

        public void InsertCompany(CompanyToAdd company)
        {
            repository.Insert(mapper.Map<Company>(company));
        }

        public void UpdateCompany(CompanyToUpdate company)
        {
            repository.Update(mapper.Map<Company>(company));
        }

    }
}
