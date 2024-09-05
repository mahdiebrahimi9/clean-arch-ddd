using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.UsersAgg.Events
{
    public class UserRegistred : BaseDomainEvent
    {
        public long UserId { get; private set; }
        public string Email { get; private set; }
        public UserRegistred(long userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}
