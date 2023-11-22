using _IdentityServer.Entities.DbModels;
using System.Linq.Expressions;

namespace _IdentityServer.Business.Services.Abstract
{
    public interface IOperationClaimsService
    {
        Task<OperationClaims> AddR(OperationClaims param);
        Task Add(OperationClaims param);
        Task<IList<OperationClaims>> AddRangeR(IList<OperationClaims> param);
        Task AddRange(IList<OperationClaims> param);
        Task Update(OperationClaims param);
        Task UpdateRange(IList<OperationClaims> param);
        Task Delete(OperationClaims param);


        Task<OperationClaims> GetSingle(Expression<Func<OperationClaims, bool>> filter, CancellationToken token);
        Task<IList<OperationClaims>> GetPlural(Expression<Func<OperationClaims, bool>> filter, CancellationToken token);
        Task<OperationClaims> GetById(int Id);
    }
}
