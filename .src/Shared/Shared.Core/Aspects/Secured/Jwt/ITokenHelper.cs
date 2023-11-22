using Shared.Backend.Core.Aspects.Secured.Jwt.Models;

namespace Shared.Backend.Core.Aspects.Secured.Jwt
{
    public interface ITokenHelper
    {
        string CreateToken(UserInfo userInfo, List<OperationClaimsInfo> operationClaimsInfo);
    }
}
