using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;


namespace Application.Features.ProgrammingLanguageTechnologies.Rules
{
    public class ProgrammingLanguageTechnologyBusinessRules
    {
        private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

        public ProgrammingLanguageTechnologyBusinessRules(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
        {
            _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
        }

        public async Task ProgrammingLanguageTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguageTechnology> result = await _programmingLanguageTechnologyRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException(name + " " + "already exist.");
        }

        public void ProgrammingLanguageTechnologyShouldExistWhenRequested(ProgrammingLanguageTechnology programmingLanguageTechnology)
        {
            if (programmingLanguageTechnology == null) throw new BusinessException("Requested programming language does not exist.");
        }
    }
}
