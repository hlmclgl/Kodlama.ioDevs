using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Application.Features.ProgrammingLanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public string Name { get; set; }

        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? programmingLanguageTechnologyToDelete = await _programmingLanguageTechnologyRepository.GetAsync(p => p.Name == request.Name);
                _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(programmingLanguageTechnologyToDelete);

                ProgrammingLanguageTechnology deletedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnologyToDelete);
                DeletedProgrammingLanguageTechnologyDto deletedProgrammingLanguageTechnologyDto = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedProgrammingLanguageTechnology);

                return deletedProgrammingLanguageTechnologyDto;
            }
        }
    }
}
