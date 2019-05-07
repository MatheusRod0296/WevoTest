using Domain.Handlers;
using Domain.Interfaces.Repository;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra
{
    public static class InjectionDependency
    {
        /// <summary>
        ///  classe utilizadaa parar a organização das injeções de dependencia
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void UseInjectionDependency(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddScoped<IPersonRespository, PersonRepository>();


            serviceCollection.AddScoped<PersonHandler, PersonHandler>();

            serviceCollection.AddScoped<Context, Context>();

        }
    }
}
