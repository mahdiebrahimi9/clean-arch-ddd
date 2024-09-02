using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Book_Domain.Shared
{
    public class Money
    {
        public int Value { get; }
        public Money(int rialValue)
        {
            if (rialValue < 0)
                throw new InvalidDataException();
            Value = rialValue;
        }

        public static Money FromRial(int value)
        {
            return new Money(value);
        }
        public static Money FromToman(int value)
        {
            return new Money(value * 10);
        }

        public static Money operator +(Money money1, Money money2)
        {
            return new Money(money1.Value + money2.Value);
        }
        public static Money operator -(Money money1, Money money2)
        {
            return new Money(money1.Value - money2.Value);
        }

        public static bool operator ==(Money money1, Money money2)
        {
            return money1.Value == money2.Value;
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return money1.Value != money2.Value;

        }
        public override string ToString()
        {
            return Value.ToString("#,0");
        }
    }
}
