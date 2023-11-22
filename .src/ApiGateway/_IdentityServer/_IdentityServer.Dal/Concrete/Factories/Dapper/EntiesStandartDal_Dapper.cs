using _IdentityServer.Dal.Abstract.Factories;
using _IdentityServer.Dal.Abstract.Factories.Dapper;
using _IdentityServer.Dal.Concrete.Factories.MongoDb;
using _IdentityServer.Entities.DbModels;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.DataAccess;

namespace _IdentityServer.Dal.Concrete.Factories.Dapper
{
    internal class EntiesStandartDal_Dapper
    {
    }


    internal class OperationClaimsDal_Dapper : RepositoryBase_Dapper<OperationClaims, RepositoryContext_Dapper>, IOperationClaimsDal_Dapper, IOperationClaimsDal
    {
        public OperationClaimsDal_Dapper() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_Dapper>()) { }
    }
    internal class UserDal_Dapper : RepositoryBase_Dapper<User, RepositoryContext_Dapper>, IUserDal_Dapper, IUserDal
    {
        public UserDal_Dapper() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_Dapper>()) { }
    }
    internal class UserOperationClaimsDal_Dapper : RepositoryBase_Dapper<UserOperationClaims, RepositoryContext_Dapper>, IUserOperationClaimsDal_Dapper, IUserOperationClaimsDal
    {
        public UserOperationClaimsDal_Dapper() : base(_IdentityServerRegisterationDal_.ServiceProvider.GetService<RepositoryContext_Dapper>()) { }
    }


}
