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

namespace Application.Features.GithubAddresses.Commands.DeleteGithubAddress
{
    public class DeleteGithubAddressCommand : IRequest<DeletedGithubAddressDto>
    {
        public int Id { get; set; }

        public class DeleteGithubAddressCommandHandler : IRequestHandler<DeleteGithubAddressCommand, DeletedGithubAddressDto>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;
            private readonly GithubAddressBusinessRules _githubAddressBusinessRules;

            public DeleteGithubAddressCommandHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper, GithubAddressBusinessRules githubAddressBusinessRules)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
                _githubAddressBusinessRules = githubAddressBusinessRules;
            }

            public async Task<DeletedGithubAddressDto> Handle(DeleteGithubAddressCommand request, CancellationToken cancellationToken)
            {

                GithubAddress? githubAddressToDelete = await _githubAddressRepository.GetAsync(g => g.Id == request.Id);
                _githubAddressBusinessRules.GithubAddressShouldExistWhenRequested(githubAddressToDelete);


                GithubAddress deletedGithubAddress = await _githubAddressRepository.DeleteAsync(githubAddressToDelete);
                DeletedGithubAddressDto deletedGithubAddressDto = _mapper.Map<DeletedGithubAddressDto>(deletedGithubAddress);

                return deletedGithubAddressDto;
            }
        }
    }
}
