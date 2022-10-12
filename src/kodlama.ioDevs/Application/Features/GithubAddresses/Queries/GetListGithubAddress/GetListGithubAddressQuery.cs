using Application.Features.GithubAddresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Queries.GetListGithubAddress
{
    public class GetListGithubAddressQuery : IRequest<GithubAddressListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGithubAddressHandler : IRequestHandler<GetListGithubAddressQuery, GithubAddressListModel>
        {
            private readonly IGithubAddressRepository _githubAddressRepository;
            private readonly IMapper _mapper;

            public GetListGithubAddressHandler(IGithubAddressRepository githubAddressRepository, IMapper mapper)
            {
                _githubAddressRepository = githubAddressRepository;
                _mapper = mapper;
            }

            public async Task<GithubAddressListModel> Handle(GetListGithubAddressQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GithubAddress> githubAddresses = await _githubAddressRepository.GetListAsync(include:
                                                                        f => f.Include(c => c.User),
                                                                        index: request.PageRequest.Page,
                                                                        size: request.PageRequest.PageSize);

                GithubAddressListModel mappedGithubAddresses = _mapper.Map<GithubAddressListModel>(githubAddresses);

                return mappedGithubAddresses;
            }
        }
    }
}
