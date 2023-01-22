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
            RuleFor(x => x)
            .Must(x => x.IsValidAmount(x.Price.Amount))
            .WithMessage("Value cannot be less or equals than zero");
        }

       
    }
}
