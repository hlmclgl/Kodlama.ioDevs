using Application.Features.ProgrammingLanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguageTechnologies.Queries.GetListProgrammingLanguageTechnologyByDynamic
{
    public class GetListProgrammingLanguageTechnologyByDynamicQuery : IRequest<ProgrammingLanguageTechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageTechnologyByDynamicQueryHandler : IRequestHandler<GetListProgrammingLanguageTechnologyByDynamicQuery, ProgrammingLanguageTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;

            public GetListProgrammingLanguageTechnologyByDynamicQueryHandler(IMapper mapper, IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository)
            {
                _mapper = mapper;
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
            }

            public async Task<ProgrammingLanguageTechnologyListModel> Handle(GetListProgrammingLanguageTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguageTechnology> programmingLanguageTechnologies = await _programmingLanguageTechnologyRepository.GetListByDynamicAsync(request.Dynamic, include:
                                              m => m.Include(c => c.ProgrammingLanguage),
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);

                ProgrammingLanguageTechnologyListModel mappedProgrammingLanguageTechnologies = _mapper.Map<ProgrammingLanguageTechnologyListModel>(programmingLanguageTechnologies);
                return mappedProgrammingLanguageTechnologies;
            }
        }
    }
}
