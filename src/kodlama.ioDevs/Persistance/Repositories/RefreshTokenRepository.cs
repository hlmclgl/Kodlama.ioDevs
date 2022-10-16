using Application.Services.Repositories;
using Core.Persistance.Repositories;
using Core.Security.Entities;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
