using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetByIdGithubAddress
{
    public class GetByIdGithubAddressQuery : IRequest<GetByIdGithubAddressDto>
    {
        public int Id { get; set; }

        public class GetByIdGithubAddressHandler : IRequestHandler<GetByIdGithubAddressQuery, GetByIdGithubAddressDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;
            private readonly GithubAddressBusinessRules _githubAddressBusinessRules;

            public GetByIdGithubAddressHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper, GithubAddressBusinessRules githubAddressBusinessRules)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
                _githubAddressBusinessRules = githubAddressBusinessRules;
            }

            public async Task<GetByIdGithubAddressDto> Handle(GetByIdGithubAddressQuery request, CancellationToken cancellationToken)
            {
                GithubAddress? githubAddress = await _githubAddressRepository.GetAsync(g => g.Id == request.Id);
                _githubAddressBusinessRules.GithubAddressShouldExistWhenRequested(githubAddress);

                GetByIdGithubAddressDto mappedGithubAddresses = _mapper.Map<GetByIdGithubAddressDto>(githubAddress);

                return mappedGithubAddresses;
            }
        }
    }
}
