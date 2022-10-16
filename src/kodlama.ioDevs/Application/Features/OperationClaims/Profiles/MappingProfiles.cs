using Application.Features.OperationClaims.Commands.CreateOperationClaimCommand;
using Application.Features.OperationClaims.Commands.DeleteOperationClaimCommand;
using Application.Features.OperationClaims.Commands.UpdateOperationClaimCommand;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
        }
    }
}
