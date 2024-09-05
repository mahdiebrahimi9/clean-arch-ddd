using Book_Domain.Shared;
using Book_Domain.Users.ValueObjects;
using Book_Domain.UsersAgg.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Users
{
    public class User : AggregateRoot
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneBook PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public User(string name, string family, PhoneBook phoneNumber, string email)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public static User Register(string email)
        {
            var user = new User("", "", null, email);
            user.AddDomainEvent(new UserRegistred(user.Id, email));
            return user;
        }
    }
}
