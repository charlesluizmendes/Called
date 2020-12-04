using Called.Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Called.Application.Validators
{
    public class DeleteTicketValidator : AbstractValidator<DeleteTicketDto>
    {
        public DeleteTicketValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .WithMessage("O Id não pode ser nulo");            
        }
    }
}
