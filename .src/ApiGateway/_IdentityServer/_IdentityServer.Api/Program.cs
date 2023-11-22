using _IdentityServer.Business;
using _IdentityServer.Dal;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Shared.Backend.Core;
using Shared.Backend.Core.Aspects.Secured.Jwt.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.ServiceRegisterationSharedBackEndCoreInit(new TokenOptionsModel());

//Connection string , Secilen ORM , Seçilen DB burada belirtilir.
//builder.Services.IdentityServerRegisterationDalInit("con", "Dapper", "PostgreSql");
builder.Services.IdentityServerRegisterationDalInit("con", "EF", "MsSql");


builder.Services.IdentityServerRegisterationBusinessInit();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new ServiceRegisterationSharedBackEndCore());
    builder.RegisterModule(new IdentityServerRegisterationDal());
    builder.RegisterModule(new IdentityServerRegisterationBusiness());
});









var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

 // swagger test tarafýnda kullanýlsýn.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
