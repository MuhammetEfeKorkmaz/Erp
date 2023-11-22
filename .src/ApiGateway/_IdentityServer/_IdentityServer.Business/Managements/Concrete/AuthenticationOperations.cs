using _IdentityServer.Business.Managements.Abstract;
using _IdentityServer.Business.Services.Abstract;
using _IdentityServer.Dal;
using _IdentityServer.Entities.DbModels;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Secured.Hashing;
using Shared.Backend.Core.Aspects.Secured.Jwt;
using Shared.Backend.Core.Aspects.Secured.Jwt.Models;
using Shared.Backend.Core.Results;

namespace _IdentityServer.Business.Managements.Concrete
{
    internal class AuthenticationOperations: IAuthenticationOperations
    {
        private IUserService userService;
        private IUserOperationClaimsService userClaimService;
        private IOperationClaimsService claimsService;
        private ITokenHelper tokenHelper;
        public AuthenticationOperations()
        {
            userService = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IUserService>();
            userClaimService = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IUserOperationClaimsService>();
            claimsService = _IdentityServerRegisterationDal_.ServiceProvider.GetService<IOperationClaimsService>();
            tokenHelper = _IdentityServerRegisterationDal_.ServiceProvider.GetService<ITokenHelper>();
        }


        public async Task<IDataResult<string>> Login(string _email, string _password)
        {
            var userToCheck = await userService.GetSingle(x => x.Email.Equals(_email), CancellationToken.None);
            if (userToCheck == null)
            {
                return new ErrorDataResult<string>("Kullanıcı bulunamadı");
            }



            if (!HashingHelper.VerifyPasswordHash(_password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<string>("Yanlış Şifre");
            }
            string jwtToken = await CreateAccessToken(userToCheck);

            return new SuccessDataResult<string>(jwtToken);
             
        }

      


        public async Task<IDataResult<string>> ForgotMyPassword(string _email)
        {  // email modülünü core dan çek.
            return await Task.FromResult(new SuccessDataResult<string>(string.Empty)); 
        }





        private async Task<string> CreateAccessToken(User _user)
        {
            var userClaim = await userClaimService.GetPlural(x => x.UserFID == _user.Id && x.IsActive, CancellationToken.None);
            if (userClaim == null)
            {
                return string.Empty;
            }
            List<OperationClaimsInfo> operationClaimsInfo = new List<OperationClaimsInfo>();
            foreach (var item in userClaim)
            {
                var row = await claimsService.GetSingle(x => x.IsActive && x.Id == item.OperationClaimsFID, CancellationToken.None);
                operationClaimsInfo.Add(new OperationClaimsInfo() { Name = row.Name });
            }


            var accessToken = tokenHelper.CreateToken(new UserInfo() { Email = _user.Email, Id = _user.Id.ToString(), Name = _user.Name, Nick = _user.Nick }
              , operationClaimsInfo);

            return accessToken;

        }



    }
}
