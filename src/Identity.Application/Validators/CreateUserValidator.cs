using FluentValidation;
using Identity.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().NotNull()
                .WithMessage("O Nome não pode ser nulo")
                .Matches(@"^[ a-zA-ZÀ-ú]*$")
                .WithMessage("O Nome deve possuir somente letras");

            RuleFor(x => x.Email)
                .NotEmpty().NotNull()
                .WithMessage("O Email não pode ser nulo")
                .EmailAddress()
                .WithMessage("O Email é inválido");

            RuleFor(x => x.Password)
               .NotEmpty().NotNull()
               .WithMessage("A Senha não pode ser nula")
               .MinimumLength(3)
               .WithMessage("A Senha deve possuir no mínimo 3 caracteres");
        }
    }
}
