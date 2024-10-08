﻿using Book_Domain.Shared;

namespace Book_Domain.Users.ValueObjects
{
    public class PhoneNumber : BaseValueObject
    {

        public string Phone { get; private set; }

        public PhoneNumber(string phone)
        {
            if (phone.Length < 11 || phone.Length > 11)
                throw new InvalidDataException();

            Phone = phone;
        }
    }
}
