using _IdentityServer.Dal.Abstract.Factories.Dapper;
using _IdentityServer.Dal.Abstract.Factories.EntitiyFramework;

namespace _IdentityServer.Dal.Abstract.Factories
{

    public interface IOperationClaimsDal : IOperationClaimsDal_EF, IOperationClaimsDal_Dapper { }
    public interface IUserDal : IUserDal_EF, IUserDal_Dapper { }
    public interface IUserOperationClaimsDal : IUserOperationClaimsDal_EF, IUserOperationClaimsDal_Dapper { }
}
