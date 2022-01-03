using DTOLayer.Collections.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.IServices
{
    public interface IUserServices
    {
        List<UserToGet> GetAll();
        UserToGet GetUser(int id);
        void InsertUser(UserToAdd user);
        void UpdateUser(UserToUpdate user);
        void DeleteUser(int id);
        UserToGet Login(string username, string password);
        bool CheckUser(string username);
    }
}
