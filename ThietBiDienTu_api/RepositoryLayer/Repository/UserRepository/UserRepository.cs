using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly ThietBiDienTuDBContext db;
        public UserRepository(ThietBiDienTuDBContext db): base(db)
        {
            this.db = db;
        }

        public bool CheckUser(string username)
        {
            User user = db.User.FirstOrDefault(x => x.UserName.Equals(username));
            if (user != null)
                return true;
            return false;
        }

        public User Login(string username, string password)
        {
            return db.User.FirstOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password));
        }
    }
}
