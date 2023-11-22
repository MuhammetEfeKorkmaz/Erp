using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Base;

namespace Shared.Backend.Core.Aspects.Caching
{
    public class CacheRemoveAspect : NormalInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceRegisterationSharedBackEndCore_.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }


    }
}
