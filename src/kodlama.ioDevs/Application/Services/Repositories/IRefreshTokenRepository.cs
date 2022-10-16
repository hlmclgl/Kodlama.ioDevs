using Core.Persistance.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {
    }



}
