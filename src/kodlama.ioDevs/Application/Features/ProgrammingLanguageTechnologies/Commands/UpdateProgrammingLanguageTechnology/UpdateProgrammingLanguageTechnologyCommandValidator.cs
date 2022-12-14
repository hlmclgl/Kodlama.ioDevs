using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
    {
        public UpdateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(1);
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty();
        }
    }
}
