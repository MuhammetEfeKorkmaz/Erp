using _IdentityServer.Business.Services.Abstract;
using _IdentityServer.Business.Services.ValidationRules;
using _IdentityServer.Dal;
using _IdentityServer.Dal.Abstract.Factories;
using _IdentityServer.Entities.DbModels;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Caching;
using Shared.Backend.Core.Aspects.Secured;
using Shared.Backend.Core.Aspects.Secured.Validation;
using System.Linq.Expressions;

namespace _IdentityServer.Business.Services.Concrete
{
    internal class UserService : IUserService
    {
        private readonly IUserDal _dal;
        public UserService()
        {
            _dal = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IUserDal>();
        }


        [CacheRemoveAspect("User.Add", Priority = 3)]
        [SecuredOperationAspect("User.Add", Priority = 1)]
        [ValidationAspect(typeof(UserValidator), OperationType.Add, Priority = 2)]
        public async Task Add(User param)
        {
            await _dal.Add(param);
        }


        [CacheRemoveAspect("User.AddR", Priority = 3)]
        [SecuredOperationAspect("User.AddR", Priority = 2)]
        [ValidationAspect(typeof(UserValidator), OperationType.Add, Priority = 1)]
        public async Task<User> AddR(User param)
        {
            return await _dal.AddR(param);
        }


        [CacheRemoveAspect("User.AddRange", Priority = 3)]
        [SecuredOperationAspect("User.AddRange", Priority = 2)]
        [ValidationAspect(typeof(UserValidator), OperationType.Add, Priority = 1)]
        public async Task AddRange(IList<User> param)
        {
            await _dal.AddRange(param);
        }


        [CacheRemoveAspect("User.AddRangeR", Priority = 3)]
        [SecuredOperationAspect("User.AddRangeR", Priority = 2)]
        [ValidationAspect(typeof(UserValidator), OperationType.Add, Priority =1)]
        public async Task<IList<User>> AddRangeR(IList<User> param)
        {
            return await _dal.AddRangeR(param);
        }


        [CacheRemoveAspect("User.Update", Priority = 3)]
        [SecuredOperationAspect("User.Update", Priority = 2)]
        [ValidationAspect(typeof(UserValidator), OperationType.Update, Priority = 1)]
        public async Task Update(User param)
        {
            await _dal.Update(param);
        }


        [CacheRemoveAspect("User.UpdateRange", Priority =3)]
        [SecuredOperationAspect("User.UpdateRange", Priority = 2)]
        [ValidationAspect(typeof(UserValidator), OperationType.Update, Priority = 1)]
        public async Task UpdateRange(IList<User> param)
        {
            await _dal.UpdateRange(param);
        }


        [CacheRemoveAspect("User.Delete", Priority = 2)]
        [SecuredOperationAspect("User.Delete", Priority = 1)]
        public async Task Delete(User param)
        {
            await _dal.Delete(param);
        }












        [CacheAspect(CacheType.Redis, Priority = 2)]
        [SecuredOperationAspect("User.GetById", Priority = 1)]
        public async Task<User> GetById(int Id)
        {
            return await _dal.GetSingle(x => x.Id == Id, CancellationToken.None);
        }



        [CacheAspect(CacheType.MicrosoftMemoryCache, Priority = 2)]
        [SecuredOperationAspect("User.GetPlural", Priority = 1)]
        public async Task<IList<User>> GetPlural(Expression<Func<User, bool>> filter, CancellationToken token)
        {
            return await _dal.GetPlural(filter, token);
        }



        [CacheAspect(CacheType.Redis, Priority = 2)]
        [SecuredOperationAspect("User.GetSingle", Priority = 1)]
        public async Task<User> GetSingle(Expression<Func<User, bool>> filter, CancellationToken token)
        {
            return await _dal.GetSingle(filter, token);
        }


    }
}
