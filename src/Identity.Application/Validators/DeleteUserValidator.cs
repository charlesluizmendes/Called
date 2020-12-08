using FluentValidation;
using Identity.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Validators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserDto>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().NotNull()
                .WithMessage("O Id não pode ser nulo");
        }
    }
}
