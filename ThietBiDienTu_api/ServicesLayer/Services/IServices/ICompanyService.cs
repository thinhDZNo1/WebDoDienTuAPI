using DTOlayer.Collections.Company;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface ICompanyService
    {
        List<CompanyToGet> GetAll();
        CompanyToGet GetCompany(int? id);
        void InsertCompany(CompanyToAdd company);
        void UpdateCompany(CompanyToUpdate company);
        void DeleteCompany(int id);
    }
}
