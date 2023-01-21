using DeliveryManager.Application.Utils;
using DeliveryManager.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Validations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x)
            .Must(x => ValidationUtils.IsValidCpf(x.Cpf))
            .WithMessage("Invalid Cpf");

            RuleFor(x => x)
            .Must(x => ValidationUtils.IsValidEmail(x.Email))
            .WithMessage("Invalid Email");
        }
    }
}
