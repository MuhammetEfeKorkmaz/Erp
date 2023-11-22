using _IdentityServer.Entities.DbModels;
using System.Linq.Expressions;

namespace _IdentityServer.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<User> AddR(User param);
        Task Add(User param);
        Task<IList<User>> AddRangeR(IList<User> param);
        Task AddRange(IList<User> param);
        Task Update(User param);
        Task UpdateRange(IList<User> param);
        Task Delete(User param);


        Task<User> GetSingle(Expression<Func<User, bool>> filter, CancellationToken token);
        Task<IList<User>> GetPlural(Expression<Func<User, bool>> filter, CancellationToken token);
        Task<User> GetById(int Id);
    }
}
