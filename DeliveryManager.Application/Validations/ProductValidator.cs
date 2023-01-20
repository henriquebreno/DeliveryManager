using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.ValueObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Price.Currency)
             .Must(x => Currency.Validate(x))
             .WithMessage($"Allowed values: " +
             $"{Currency.Real.Name},{Currency.Euro.Name},{Currency.CanadianDollar.Name},{Currency.USDollar.Name}");

            RuleFor(x => x)
            .Must(x => x.IsValidAmount(x.Price.Amount))
            .WithMessage("Value cannot be less or equals than zero");
        }

       
    }
}
