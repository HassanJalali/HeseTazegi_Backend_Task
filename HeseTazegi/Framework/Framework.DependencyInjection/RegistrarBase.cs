using Framework.ApplicationService;
using Framework.ApplicationService.Behaviours;
using Framework.Core.DependencyInjection;
using Framework.Core.Domain;
using Framework.Core.Facade;
using Framework.Core.Persistence;
using Framework.ReadModel;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Framework.DependencyInjection
{
    public class RegistrarBase : IRegistrar
    {
        protected IServiceCollection _serviceCollection;

        public virtual void Register(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
            RegisterTransient<IEntityMapping>();
            RegisterTransient<IRepository>();
            RegisterTransient<IDomainService>();
            RegisterTransient<ICommandFacade>();
            RegisterTransient<IQueryFacade>();
            RegisterBehaviour();
        }
        private void RegisterBehaviour()
        {
            _serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehaviour<,>));
        }
        private void RegisterTransient<TRegisterBase>()
        {
            _serviceCollection.Scan(s =>
                s.FromApplicationDependencies()
                    .AddClasses(c => c.AssignableTo<TRegisterBase>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                    .AsMatchingInterface()
                    .WithTransientLifetime());
        }
        private void RegisterScoped<TRegisterBase>()
        {
            _serviceCollection.Scan(s =>
                s.FromApplicationDependencies()
                    .AddClasses(c => c.AssignableTo<TRegisterBase>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Throw)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}
