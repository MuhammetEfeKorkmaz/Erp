using Shared.Backend.Core.Results;

namespace _IdentityServer.Business.Managements.Abstract
{
    public interface IAuthenticationOperations
    {
        Task<IDataResult<string>> Login(string _email, string _password);
        Task<IDataResult<string>> ForgotMyPassword(string _email);
    }
}
