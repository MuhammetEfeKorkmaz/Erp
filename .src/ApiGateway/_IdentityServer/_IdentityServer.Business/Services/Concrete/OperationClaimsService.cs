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

    internal class OperationClaimsService : IOperationClaimsService
    {
        private readonly IOperationClaimsDal _dal;
        public OperationClaimsService()
        {
            _dal = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IOperationClaimsDal>();
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task Add(OperationClaims param)
        {
            await _dal.Add(param);
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task<OperationClaims> AddR(OperationClaims param)
        {
            return await _dal.AddR(param);
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task AddRange(IList<OperationClaims> param)
        {
            await _dal.AddRange(param);
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Add, Priority = 1)]
        public async Task<IList<OperationClaims>> AddRangeR(IList<OperationClaims> param)
        {
            return await _dal.AddRangeR(param);
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Update, Priority = 1)]
        public async Task Update(OperationClaims param)
        {
            await _dal.Update(param);
        }



        [ValidationAspect(typeof(OperationClaimsValidator), OperationType.Update, Priority = 1)]
        public async Task UpdateRange(IList<OperationClaims> param)
        {
            await _dal.UpdateRange(param);
        }



        public async Task Delete(OperationClaims param)
        {
            await _dal.Delete(param);
        }







        public async Task<OperationClaims> GetById(int Id)
        {
            return await _dal.GetSingle(x => x.Id == Id, CancellationToken.None);
        }
        public async Task<IList<OperationClaims>> GetPlural(Expression<Func<OperationClaims, bool>> filter, CancellationToken token)
        {
            return await _dal.GetPlural(filter, token);
        }
        public async Task<OperationClaims> GetSingle(Expression<Func<OperationClaims, bool>> filter, CancellationToken token)
        {
            return await _dal.GetSingle(filter, token);
        }


    }
}
