using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.ValueObject
{
    public class Money : ValueObject
    {
        private Money() { }

        public Money(decimal amount)
        {
            Amount = amount;
        }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; private set; }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Amount);
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
