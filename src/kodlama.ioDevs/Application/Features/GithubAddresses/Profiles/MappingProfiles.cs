using Application.Features.GithubAddresses.Commands.CreateGithubAddress;
using Application.Features.GithubAddresses.Commands.DeleteGithubAddress;
using Application.Features.GithubAddresses.Commands.UpdateGithubAddress;
using Application.Features.GithubAddresses.Dtos;
using Application.Features.GithubAddresses.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAddresses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GithubAddress, CreatedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, CreateGithubAddressCommand>().ReverseMap();

            CreateMap<GithubAddress, DeletedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, DeleteGithubAddressCommand>().ReverseMap();

            CreateMap<GithubAddress, UpdatedGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, UpdateGithubAddressCommand>().ReverseMap();

            CreateMap<IPaginate<GithubAddress>, GithubAddressListModel>().ReverseMap();
            CreateMap<GithubAddress, GetListGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, GetByIdGithubAddressDto>().ReverseMap();
            CreateMap<GithubAddress, GetListGithubAddressDto>().ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.FirstName + c.User.LastName)).ReverseMap();
        }
    }
}
