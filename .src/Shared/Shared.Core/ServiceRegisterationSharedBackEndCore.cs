using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shared.Backend.Core.Aspects;
using Shared.Backend.Core.Aspects.Base;
using Shared.Backend.Core.Aspects.Caching.Factories;
using Shared.Backend.Core.Aspects.Caching;
using Shared.Backend.Core.Aspects.Secured.Jwt;
using Shared.Backend.Core.Aspects.Secured.Jwt.Models;
using Module = Autofac.Module;
using ServiceStack.Redis;

namespace Shared.Backend.Core
{
    public class ServiceRegisterationSharedBackEndCore : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
     .EnableInterfaceInterceptors(new ProxyGenerationOptions() { Selector = new InterceptorCollection() }).SingleInstance();


        }
    }

  
    public static class ServiceRegisterationSharedBackEndCore_
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceProvider ServiceRegisterationSharedBackEndCoreInit(this IServiceCollection services, TokenOptionsModel  _tokenOptionsModel)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, Cache_MM>();
            services.AddSingleton<IRedisClient, RedisClient>(); 

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>(); 
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<ITokenHelper>(provider => new JwtHelper(_tokenOptionsModel));
            ServiceProvider = services.BuildServiceProvider();
            return ServiceProvider;
        }
    }

}
