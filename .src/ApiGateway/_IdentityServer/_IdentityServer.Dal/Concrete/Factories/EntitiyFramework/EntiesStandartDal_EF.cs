using _IdentityServer.Dal.Abstract.Factories;
using _IdentityServer.Dal.Abstract.Factories.EntitiyFramework;
using _IdentityServer.Entities.DbModels;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.DataAccess;

namespace _IdentityServer.Dal.Concrete.Factories.EntitiyFramework
{
    internal class OperationClaimsDal_EF : RepositoryBase_EF<OperationClaims, RepositoryContext_EF>, IOperationClaimsDal_EF, IOperationClaimsDal
    {
        public OperationClaimsDal_EF() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_EF>()) { }
    }
    internal class UserDal_EF : RepositoryBase_EF<User, RepositoryContext_EF>, IUserDal_EF, IUserDal
    {
        public UserDal_EF() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_EF>()) { }
    }
    internal class UserOperationClaimsDal_EF : RepositoryBase_EF<UserOperationClaims, RepositoryContext_EF>, IUserOperationClaimsDal_EF, IUserOperationClaimsDal
    {
        public UserOperationClaimsDal_EF() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_EF>()) { }
    }
}
