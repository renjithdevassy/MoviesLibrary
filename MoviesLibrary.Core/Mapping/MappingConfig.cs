using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MoviesLibrary.API.Models;
using MoviesLibrary.Data.Entities;

namespace MoviesLibrary.Core.Mapping
{
    public static class MappingConfig
    {
        public static void AddMapping(this IServiceCollection serviceCollection)
        {
            var cfg = new MapperConfiguration(x =>
            {
                x.CreateMap<MoviesEntity, MoviesModel>()
               .ReverseMap();
                
            });
            var mapper = cfg.CreateMapper();

            serviceCollection.AddSingleton(mapper);
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
