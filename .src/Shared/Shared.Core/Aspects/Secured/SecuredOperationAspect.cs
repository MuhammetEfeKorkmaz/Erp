using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Base;
using Shared.Backend.Core.Aspects.Secured.Extensions;

namespace Shared.Backend.Core.Aspects.Secured
{
    public class SecuredOperationAspect : NormalInterception
    {
        private string[] _roles;
        private IActionContextAccessor _httpContextAccessor;

        public SecuredOperationAspect(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceRegisterationSharedBackEndCore_.ServiceProvider.GetService<IActionContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.ActionContext.HttpContext.User.ClaimRoles(); 
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                    return;
            }


            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            throw new Exception("401", new Exception(key));

        }
    }
}
