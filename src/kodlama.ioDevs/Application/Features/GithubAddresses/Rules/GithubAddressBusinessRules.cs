using Application.Features.GithubAddresses.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Rules
{
    public class GithubAddressBusinessRules
    {
        private readonly IGithubAddressRepository _githubAddressRepository;

        public GithubAddressBusinessRules(IGithubAddressRepository githubAddressRepository)
        {
            _githubAddressRepository = githubAddressRepository;
        }

        public async Task GithubAddressCanNotBeDuplicatedWhenInserted(string githubUrl)
        {
            IPaginate<GithubAddress> result = await _githubAddressRepository.GetListAsync(g => g.GithubUrl == githubUrl);
            if (result.Items.Any()) throw new BusinessException(GithubAddressMessages.GithubAddressCanNotBeDuplicatedWhenInserted);
        }

        public void GithubAddressShouldExistWhenRequested(GithubAddress githubAddress)
        {
            if (githubAddress == null) throw new BusinessException(GithubAddressMessages.GithubAddressShouldExistWhenRequested);
        }
    }
}
