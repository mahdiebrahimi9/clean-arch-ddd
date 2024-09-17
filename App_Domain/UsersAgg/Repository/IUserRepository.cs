using Book_Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.UsersAgg.Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        Task<User> GetById(long id);
        Task Save();
    }
}
