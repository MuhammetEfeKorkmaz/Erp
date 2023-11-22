using _IdentityServer.Entities.DbModels;
using Shared.Backend.Core.DataAccess;

namespace _IdentityServer.Dal.Abstract.Factories.EntitiyFramework
{
    public interface IOperationClaimsDal_EF : IRepositoryBase<OperationClaims> { }
    public interface IUserDal_EF : IRepositoryBase<User> { }
    public interface IUserOperationClaimsDal_EF : IRepositoryBase<UserOperationClaims> { }
}
