using Application.Features.Auths.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.Login
{
    public class LogginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LogginCommandValidator()
        {
            RuleFor(x => x.UserForLoginDto.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(AuthMessages.UserEmailIsRequired);

            RuleFor(x => x.UserForLoginDto.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(AuthMessages.UserPasswordIsRequired);

        }
    }
}
