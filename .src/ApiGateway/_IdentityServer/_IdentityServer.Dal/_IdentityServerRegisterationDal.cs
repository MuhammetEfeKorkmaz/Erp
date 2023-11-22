using _IdentityServer.Dal.Abstract.Factories;
using _IdentityServer.Dal.Concrete.Factories.Dapper;
using _IdentityServer.Dal.Concrete.Factories.EntitiyFramework;
using _IdentityServer.Dal.Concrete.Factories.MongoDb;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Backend.Core.Aspects.Base;

namespace _IdentityServer.Dal
{

    public class IdentityServerRegisterationDal : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                { Selector = new InterceptorCollection() }).SingleInstance();
        }
    }

    public static class _IdentityServerRegisterationDal_
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider IdentityServerRegisterationDalInit(this IServiceCollection services, string _connectionString, string _selectedOrm, string _selectedDb)
        {
           
            if (_selectedOrm.Equals("EF"))
            {
                if (_selectedDb.Equals("MsSql"))
                {
                    services.AddDbContext<RepositoryContext_EF>(op => op.UseSqlServer(_connectionString));
                }
                else if (_selectedDb.Equals("PostgreSql"))
                {
                    int MaxRetryCouns = 5;
                    int MaxRetryDelaySeconds = 2;
                    services.AddDbContext<RepositoryContext_EF>(op => op.UseNpgsql(_connectionString,
                        builder => builder.EnableRetryOnFailure(MaxRetryCouns, TimeSpan.FromSeconds(MaxRetryDelaySeconds), null)));
                }
                else
                {
                    throw new Exception("Kullanılacak Veri Tabanı Belirtilmedi.");
                }
                 
                services.AddSingleton<IOperationClaimsDal>(sp => new OperationClaimsDal_EF());
                services.AddSingleton<IUserDal>(sp => new UserDal_EF());
                services.AddSingleton<IUserOperationClaimsDal>(sp => new UserOperationClaimsDal_EF());
                

            }
            else if (_selectedOrm.Equals("Dapper"))
            {
                if (_selectedDb.Equals("MsSql"))
                {
                    services.AddDbContext<RepositoryContext_Dapper>(op => op.UseSqlServer(_connectionString));
                }
                else if (_selectedDb.Equals("PostgreSql"))
                {
                    int MaxRetryCouns = 5;
                    int MaxRetryDelaySeconds = 2;
                    services.AddDbContext<RepositoryContext_Dapper>(op => op.UseNpgsql(_connectionString,
                        builder => builder.EnableRetryOnFailure(MaxRetryCouns, TimeSpan.FromSeconds(MaxRetryDelaySeconds), null)));
                }
                else
                {
                    throw new Exception("Kullanılacak Veri Tabanı Belirtilmedi.");
                }

                services.AddSingleton<IOperationClaimsDal>(sp => new OperationClaimsDal_Dapper());
                services.AddSingleton<IUserDal>(sp => new UserDal_Dapper());
                services.AddSingleton<IUserOperationClaimsDal>(sp => new UserOperationClaimsDal_Dapper());
            }
            else
            {
                throw new Exception("Kullanılacak Veri Tabanı Belirtilmedi.");
            }

            return services.BuildServiceProvider();

        }
    }



}
