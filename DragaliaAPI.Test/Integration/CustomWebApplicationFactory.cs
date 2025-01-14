﻿using DragaliaAPI.Database;
using DragaliaAPI.Models.Options;
using DragaliaAPI.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DragaliaAPI.Test.Integration;

// TODO: create a test fixture which instead contains this and let the test fixture handle database updates etc
public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    private readonly SqliteConnection connection = new("Filename=:memory:");

    public readonly Mock<IBaasRequestHelper> mockBaasRequestHelper = new();

    public readonly Mock<IOptionsMonitor<LoginOptions>> mockLoginOptions = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            ServiceDescriptor sqlDescriptor = services.Single(
                d => d.ServiceType == typeof(DbContextOptions<ApiContext>)
            );

            ServiceDescriptor redisDescriptor = services.Single(
                d =>
                    d.ServiceType == typeof(IDistributedCache)
                    && (d.ImplementationType?.Name ?? "").Contains("Redis")
            );

            services.Remove(sqlDescriptor);
            services.Remove(redisDescriptor);

            connection.Open();

            services.AddDbContext<ApiContext>(options => options.UseSqlite(connection));
            services.AddDistributedMemoryCache();

            services.AddScoped(x => mockBaasRequestHelper.Object);
            services.AddScoped(x => mockLoginOptions.Object);
        });

        builder.UseEnvironment("Testing");
    }
}
