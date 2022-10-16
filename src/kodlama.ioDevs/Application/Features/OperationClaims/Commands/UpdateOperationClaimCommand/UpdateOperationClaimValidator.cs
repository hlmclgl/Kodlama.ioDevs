using Application.Features.OperationClaims.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaimCommand
{
    public class UpdateOperationClaimValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(OperationClaimMessages.OperationClaimIsRequired);
        }
    }
}
