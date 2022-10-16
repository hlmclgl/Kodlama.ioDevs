using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (result.Items.Any()) throw new BusinessException(name + " " + ProgrammingLanguageMessages.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted);
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageShouldExistWhenRequested);
        }
    }
}
