using Called.Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Validators
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketDto>
    {
        public CreateTicketValidator()
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

            RuleFor(x => x.Complaint)
                .NotEmpty().NotNull()
                .WithMessage("A Reclamação não pode ser nula");
        }
    }
}
