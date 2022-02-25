using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using MoviesLibrary.Core.Mapping;
using MoviesLibrary.Core.Domain;
using MoviesLibrary.Data;

namespace MoviesLibrary.Core.Extensions
{
    public static class RegistrationConfig
    {
        public static void RegisterClasses(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IObjectMapper, ObjectMapper>();


          
            serviceCollection.Scan(scan =>
                      scan.FromAssemblyOf<IMoviesReader>()
                     .AddClasses()
                     .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     .AsMatchingInterface()
                     .WithScopedLifetime());

                     //for Data assembly
                     serviceCollection.Scan(scan =>
                      scan.FromAssemblyOf<IMoviesDataReader>()
                     .AddClasses()
                     .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     .AsMatchingInterface()
                     .WithScopedLifetime());

                     //serviceCollection.Scan(scan =>
                     // scan.FromAssemblyOf<IClientDataWriter>()
                     //.AddClasses()
                     //.UsingRegistrationStrategy(RegistrationStrategy.Skip)
                     //.AsMatchingInterface()
                     //.WithScopedLifetime());

        }
    }
}
