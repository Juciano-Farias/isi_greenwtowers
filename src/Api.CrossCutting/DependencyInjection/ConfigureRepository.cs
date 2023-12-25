using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.Extensions.DependencyInjection;
using Api.Service.Services;
using Api.Domain.Interfaces;
using Api.Data.Repository;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(options => options.UseNpgsql("Host=localhost;Port=5434;Database=pa;Username=postgres;Password=postgres"));
        }

    }
}