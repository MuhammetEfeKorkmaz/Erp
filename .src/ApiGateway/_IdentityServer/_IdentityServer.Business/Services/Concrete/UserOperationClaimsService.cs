using _IdentityServer.Business.Services.Abstract;
using _IdentityServer.Business.Services.ValidationRules;
using _IdentityServer.Dal;
using _IdentityServer.Dal.Abstract.Factories;
using _IdentityServer.Entities.DbModels;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Secured.Validation;
using System.Linq.Expressions;

namespace _IdentityServer.Business.Services.Concrete
{

    internal class UserOperationClaimsService : IUserOperationClaimsService
    {
        private readonly IUserOperationClaimsDal _dal;
        public UserOperationClaimsService()
        {
            _dal = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IUserOperationClaimsDal>();
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task Add(UserOperationClaims param)
        {
            await _dal.Add(param);
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task<UserOperationClaims> AddR(UserOperationClaims param)
        {
            return await _dal.AddR(param);
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task AddRange(IList<UserOperationClaims> param)
        {
            await _dal.AddRange(param);
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task<IList<UserOperationClaims>> AddRangeR(IList<UserOperationClaims> param)
        {
            return await _dal.AddRangeR(param);
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Update, Priority = 1)]
        public async Task Update(UserOperationClaims param)
        {
            await _dal.Update(param);
        }



        [ValidationAspect(typeof(UserOperationClaimsValidator), OperationType.Update, Priority = 1)]
        public async Task UpdateRange(IList<UserOperationClaims> param)
        {
            await _dal.UpdateRange(param);
        }



        public async Task Delete(UserOperationClaims param)
        {
            await _dal.Delete(param);
        }







        public async Task<UserOperationClaims> GetById(int Id)
        {
            return await _dal.GetSingle(x => x.Id == Id, CancellationToken.None);
        }
        public async Task<IList<UserOperationClaims>> GetPlural(Expression<Func<UserOperationClaims, bool>> filter, CancellationToken token)
        {
            return await _dal.GetPlural(filter, token);
        }
        public async Task<UserOperationClaims> GetSingle(Expression<Func<UserOperationClaims, bool>> filter, CancellationToken token)
        {
            return await _dal.GetSingle(filter, token);
        }


    }
}
