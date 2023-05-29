using Autofac;
using CustomerManagementAPI.Application.Commands;
using CustomerManagementAPI.Application.Queries;
using MediatR;
using System.Reflection;

namespace CustomerManagementAPI.Application.IoC
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateCustomerCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(DeleteCustomerCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterType<CustomerQueries>()
               .As<ICustomerQueries>()
               .InstancePerLifetimeScope();

            



           
        }
    }
}
