using Book_Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Users.ValueObjects
{
    public class PhoneBook : BaseValueObject
    {
        public PhoneNumber PhoneNumber { get; }
        public PhoneNumber Fax { get; }

        public PhoneBook(PhoneNumber phoneNumber, PhoneNumber fax)
        {
            PhoneNumber = phoneNumber;
            Fax = fax;
        }
    }
}
