using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        User Login(string username, string password);
        bool CheckUser(string username);
    }
}
