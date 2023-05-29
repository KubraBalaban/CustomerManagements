using Autofac;
using Autofac.Extensions.DependencyInjection;
using CustomerManagementAPI;
using CustomerManagementAPI.App.Helper;
using CustomerManagementAPI.App.Helper.Interface;
using CustomerManagementAPI.Application.IoC;
using CustomerManagementAPI.Infrastructure.Data.Context;
using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
Swagger.AddSwagger(builder.Services);
builder.Services.AddDbContext<CustomerContext>(options => options.UseNpgsql(configuration["ConnectionString"]));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new ApplicationModule());
    });
builder.Services.AddScoped<JwtTokenHandler, JwtTokenHandler>();
builder.Services.AddScoped<ISecurityTokenHandler, SecurityTokenHandler>();
builder.Services.AddCustomJwtAuthentication();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddCors(o => o.AddPolicy("CustomerManagementPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("CustomerManagementPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await MigrationDatabase.Run(app);

app.Run();




