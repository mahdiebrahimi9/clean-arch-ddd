using Book_Domain.Shared.Exceptions;

namespace Book_Domain.Shared
{
    public class Money
    {
        private Money() { }
        public Money(int rialValue)
        {
            if (rialValue < 0)
                throw new InvalidDomainDataException();
            Value = rialValue;
        }

        public int Value { get; private set; }
     

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
