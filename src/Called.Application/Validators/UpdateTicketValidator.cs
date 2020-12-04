using Called.Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Validators
{
    public class UpdateTicketValidator : AbstractValidator<TicketDto>
    {
        public UpdateTicketValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .WithMessage("O Id não pode ser nulo");

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
