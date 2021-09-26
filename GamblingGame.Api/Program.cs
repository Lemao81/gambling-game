using System;
using GamblingGame.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;

namespace GamblingGame.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var serviceScope = host.Services.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<GamblingGameDbContext>();
            try
            {
                Policy.Handle<SqlException>()
                    .WaitAndRetry(6, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)))
                    .Execute(() =>
                    {
                        dbContext.Database.Migrate();
                        Console.WriteLine("Migration succeeded");
                    });
            }
            catch (Exception)
            {
                Console.WriteLine("Migration failed");
                throw;
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
