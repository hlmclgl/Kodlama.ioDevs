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

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology
{
    public class GetByIdProgrammingLanguageTechnologyQuery : IRequest<GetByIdProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageTechnologyQueryHandler : IRequestHandler<GetByIdProgrammingLanguageTechnologyQuery, GetByIdProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public GetByIdProgrammingLanguageTechnologyQueryHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingLanguageTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }


            public async Task<GetByIdProgrammingLanguageTechnologyDto> Handle(GetByIdProgrammingLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguageTechnology? programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync( p => p.Id == request.Id );
                _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

                GetByIdProgrammingLanguageTechnologyDto getByIdProgrammingLanguageTechnologyDto = _mapper.Map<GetByIdProgrammingLanguageTechnologyDto>(programmingLanguageTechnology);
                return getByIdProgrammingLanguageTechnologyDto;


            }
        }
    }
}
