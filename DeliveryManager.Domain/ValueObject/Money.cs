using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.ValueObject
{
    public class Money : ValueObject
    {
        private Money() { }

        public Money(Currency currency, decimal amount)
        {
            Amount = amount;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public decimal Amount { get; set ; }
        public Currency Currency { get; set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Amount, this.Currency);
        }

        public override bool Equals(object obj)
        {
            return obj is Money other &&
                   this.Amount == other.Amount &&
                   this.Currency == other.Currency;
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
