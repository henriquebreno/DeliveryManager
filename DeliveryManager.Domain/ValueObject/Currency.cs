using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryManager.Domain.ValueObject
{
    public class Currency : ValueObject
    {
        public Currency(string name, string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentNullException(nameof(symbol));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Amount cannot be null or whitespace.", nameof(name));

            Symbol = symbol;
            Name = name;
        }

        public Currency()
        {
                
        }

        public string Name { get; set; }
        public string Symbol { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Currency other &&
                   this.Symbol == other.Symbol;
        }

        public override int GetHashCode() => this.Symbol.GetHashCode();

        public override string ToString()
        {
            return this.Symbol;
        }



        private static readonly IDictionary<string, Currency> _currencies;

        static Currency()
        {
            _currencies = new Dictionary<string, Currency>()
            {
                { Euro.Name, Euro },
                { CanadianDollar.Name, CanadianDollar },
                { USDollar.Name, USDollar },
                { Real.Name, Real }
            };
        }

        public static Currency FromCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException(nameof(code));
            if (!_currencies.ContainsKey(code))
                throw new ArgumentException($"Invalid code: {code}", nameof(code));
            return _currencies[code];
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static Currency Real => new Currency("BRL", "R$");
        public static Currency Euro => new Currency("EUR", "€");
        public static Currency CanadianDollar => new Currency("CAD", "CA$");
        public static Currency USDollar => new Currency("USD", "US$");

        public static bool Validate(Currency currency) 
        {
            return Currency._currencies.Any(c => c.Key.Equals(currency.Name) && c.Value.Symbol.Equals(currency.Symbol));
        }

    }
}
