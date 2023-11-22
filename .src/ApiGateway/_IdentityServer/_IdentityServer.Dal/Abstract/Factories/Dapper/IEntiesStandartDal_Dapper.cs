using _IdentityServer.Entities.DbModels;
using Shared.Backend.Core.DataAccess;

namespace _IdentityServer.Dal.Abstract.Factories.Dapper
{

    public interface IOperationClaimsDal_Dapper : IRepositoryBase<OperationClaims> { }
    public interface IUserDal_Dapper : IRepositoryBase<User> { }
    public interface IUserOperationClaimsDal_Dapper : IRepositoryBase<UserOperationClaims> { }


}
