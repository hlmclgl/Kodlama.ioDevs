using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Commands.CreateGithubAddress
{
    public class CreateGithubAddressCommand : IRequest<CreatedGithubAddressDto>
    {
        public int UserId { get; set; }
        public string GithubUrl { get; set; }

        public class CreateGithubAddressCommandHandler : IRequestHandler<CreateGithubAddressCommand, CreatedGithubAddressDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;
            private readonly GithubAddressBusinessRules _githubAddressBusinessRules;

            public CreateGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper, GithubAddressBusinessRules githubAddressBusinessRules)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
                _githubAddressBusinessRules = githubAddressBusinessRules;
            }

            public async Task<CreatedGithubAddressDto> Handle(CreateGithubAddressCommand request, CancellationToken cancellationToken)
            {
                await _githubAddressBusinessRules.GithubAddressCanNotBeDuplicatedWhenInserted(request.GithubUrl);


                GithubAddress mappedGithubAddress = _mapper.Map<GithubAddress>(request);
                GithubAddress createdGithubAddress = await _githubAddressRepository.AddAsync(mappedGithubAddress);
                CreatedGithubAddressDto createdGithubAddressDto = _mapper.Map<CreatedGithubAddressDto>(createdGithubAddress);

                return createdGithubAddressDto;
            }
        }
    }
}
