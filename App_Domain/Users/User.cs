using Book_Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Users
{
    public class User
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public PhoneBook PhoneNumber { get; private set; }
        public User(string name, string family, PhoneBook phoneNumber)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
         
        }
    }
}
