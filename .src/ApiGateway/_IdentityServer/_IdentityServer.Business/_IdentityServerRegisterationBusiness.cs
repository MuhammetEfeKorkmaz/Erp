using _IdentityServer.Business.Managements.Abstract;
using _IdentityServer.Business.Managements.Concrete;
using _IdentityServer.Business.Services.Abstract;
using _IdentityServer.Business.Services.Concrete;
using _IdentityServer.Dal;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Base;

namespace _IdentityServer.Business
{


    public class IdentityServerRegisterationBusiness : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
                { Selector = new InterceptorCollection() }).SingleInstance();
        }
    }


    public static class _IdentityServerRegisterationBusiness_
    {
        public static IServiceProvider IdentityServerRegisterationBusinessInit(this IServiceCollection services)
        { 
            services.AddSingleton<IOperationClaimsService, OperationClaimsService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserOperationClaimsService, UserOperationClaimsService>();
            services.AddSingleton<IAuthenticationOperations, AuthenticationOperations>();  


            var builder = new ContainerBuilder();
            builder.Populate(services);
            _IdentityServerRegisterationDal_.ServiceProvider = new AutofacServiceProvider(builder.Build());

            return _IdentityServerRegisterationDal_.ServiceProvider;
        }

    }
}
