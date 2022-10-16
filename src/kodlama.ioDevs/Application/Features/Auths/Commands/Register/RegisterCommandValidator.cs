using Application.Features.Auths.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserEmailIsRequired);

            RuleFor(x => x.UserForRegisterDto.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserPasswordIsRequired);

            RuleFor(x => x.UserForRegisterDto.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserFirstNameIsRequired);

            RuleFor(x => x.UserForRegisterDto.LastName)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserLastNameIsRequired);
        }
    }
}
