using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using GamblingGame.Api.Filters;
using GamblingGame.Api.Middlewares;
using GamblingGame.Api.Models.Dtos;
using GamblingGame.Api.Validators;
using GamblingGame.Domain.Consts;
using GamblingGame.Domain.Interfaces;
using GamblingGame.Domain.Models;
using GamblingGame.Domain.Services;
using GamblingGame.Repo;
using GamblingGame.Repo.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

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

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter(typeof(CamelCaseNamingStrategy)));
                });

            services.AddMvc(options => options.Filters.Add<DomainExceptionFilter>()).AddFluentValidation();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IGamblingService, GamblingService>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
            services.AddScoped<IAuthenticateContext, AuthenticateContext>();
            services.AddScoped<ILotteryWheel, LotteryWheel>();
            services.AddScoped<IValidator<GambleRequest>, GambleRequestValidator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Const.JwtSecret))
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<AuthenticateMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Gambling}/{action=Gamble}");
            });
        }
    }
}
