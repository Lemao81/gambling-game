using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;
using GamblingGame.Domain.Services;
using GamblingGame.Repo;
using GamblingGame.Repo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GamblingGame.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GamblingGameDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Local")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IGamblingService, GamblingService>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
            services.AddScoped<IAuthenticateContext, AuthenticateContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Gambling}/{action=Gamble}");
            });
        }
    }
}
