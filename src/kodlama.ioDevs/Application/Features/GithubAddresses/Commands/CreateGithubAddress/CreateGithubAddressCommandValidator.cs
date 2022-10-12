using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommandValidator : AbstractValidator<CreateGithubAddressCommand>
    {
        public CreateGithubAddressCommandValidator()
        {
            RuleFor(c => c.GithubUrl).NotEmpty();
            RuleFor(c => c.GithubUrl).MinimumLength(5);
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
