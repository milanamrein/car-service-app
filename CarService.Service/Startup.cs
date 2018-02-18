using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using CarService.Service.Repositories;

namespace CarService.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // adding DbContext and ConnectionString
            services.AddDbContext<CarServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CarServiceConnection")));

            // enabling Cross-Origin Resource Sharing so that the front-end can get the HTTP response
            services.AddCors(options => options
                .AddPolicy("CorsPolicy", policy => 
                    policy.WithOrigins(Configuration["Client"]).AllowAnyHeader().AllowAnyMethod()));

            // adding Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CarServiceContext>()
                .AddDefaultTokenProviders();

            // configure JWT in middleware to validate the token
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = Configuration["JwtSecurityToken:Audience"],
                    ValidIssuer = Configuration["JwtSecurityToken:Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityToken:Key"])),
                    ValidateLifetime = true
                };
            });

            // adding AutoMapper to DI Container
            services.AddAutoMapper();

            // adding Unit Of Work and Authentication Repository to DI Container
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthRepository, AuthRepository>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // using CorsPolicy
            app.UseCors("CorsPolicy");

            // include user authentication as part of the middleware pipeline
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
