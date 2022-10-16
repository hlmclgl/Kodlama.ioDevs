using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaimCommand
{
    public class CreateOperationClaimValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(OperationClaimMessages.OperationClaimIsRequired);
        }
    }
}
