using _IdentityServer.Entities.DbModels;
using System.Linq.Expressions;

namespace _IdentityServer.Business.Services.Abstract
{
    public interface IUserOperationClaimsService
    {
        Task<UserOperationClaims> AddR(UserOperationClaims param);
        Task Add(UserOperationClaims param);
        Task<IList<UserOperationClaims>> AddRangeR(IList<UserOperationClaims> param);
        Task AddRange(IList<UserOperationClaims> param);
        Task Update(UserOperationClaims param);
        Task UpdateRange(IList<UserOperationClaims> param);
        Task Delete(UserOperationClaims param);


        Task<UserOperationClaims> GetSingle(Expression<Func<UserOperationClaims, bool>> filter, CancellationToken token);
        Task<IList<UserOperationClaims>> GetPlural(Expression<Func<UserOperationClaims, bool>> filter, CancellationToken token);
        Task<UserOperationClaims> GetById(int Id);
    }
}
