using Application.Services.Repositories;
using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Core.Persistance.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using Persistance.Contexts;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {

        public ProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {
        }

        
    }
}
