using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaimCommand
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>
    {
        public int Id { get; set; }

        //public string[] Roles => new[] { Admin, UserOperationClaimDelete };

        public class
            DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand,
                DeletedUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository,
                                                          IMapper mapper,
                                                          UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request,
                                                                   CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserOperationClaimIdShouldExistWhenSelected(request.Id);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deletedUserOperationClaim =
                    await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);
                DeletedUserOperationClaimDto deletedUserOperationClaimDto =
                    _mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);
                return deletedUserOperationClaimDto;
            }
        }
    }
}
