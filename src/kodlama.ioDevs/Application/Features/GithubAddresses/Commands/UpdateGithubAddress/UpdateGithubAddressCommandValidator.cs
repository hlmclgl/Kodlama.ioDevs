using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.UpdateGithubAddress
{
    public class UpdateGithubAddressCommandValidator : AbstractValidator<UpdateGithubAddressCommand>
    {
        public UpdateGithubAddressCommandValidator()
        {
            RuleFor(c => c.GithubUrl).NotEmpty();
            RuleFor(c => c.GithubUrl).MinimumLength(5);
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
