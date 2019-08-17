using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using server.Context;
using server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft.Json;
using server.Context.Realms.MountOlympus;
using server.Context.Realms.TitansLeague;
using server.Context.Realms.TwinkNation;
using server.Data.Characters;
using server.Data.Realms;
using server.Services;
using server.Util;

namespace server
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
            // other service configurations go here
            services.AddEntityFrameworkMySql()
                .AddDbContext<WebsiteContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("WebsiteConnection")));

            services.AddEntityFrameworkMySql()
                .AddDbContext<AuthContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("AuthConnection")));

            var realms = Configuration.GetSection("Realms").Get<Realm[]>();

            foreach (var realm in realms)
            {
                switch (realm.RealmType)
                {
                    case RealmInformation.RealmType.TitansLeague:
                    {
                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TitansLeagueCharacterContext>(options =>
                                options.UseMySql(realm.CharacterConnection));
                            break;
                    }
                    case RealmInformation.RealmType.TwinkNation:
                    {
                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TwinkNationCharacterContext>(options =>
                                options.UseMySql(realm.CharacterConnection));
                            break;
                    }
                    case RealmInformation.RealmType.MountOlympus:
                    {
                        services.AddEntityFrameworkMySql()
                            .AddDbContext<MountOlympusCharacterContext>(options =>
                                options.UseMySql(realm.CharacterConnection));
                            break;
                    }
                }
            }

            services.AddScoped<ContextService>();

            services.AddScoped<UserPermissions>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<WebsiteContext>()
                .AddDefaultTokenProviders();

            /*services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });*/

            string JWTKey = Configuration.GetSection("JWTKey")
                                      .GetSection("SecureKey")
                                      .Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "Titans-League",
                    ValidIssuer = "Titans-League",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKey))
                };
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("37.59.62.229"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Create Base User
            //SeedDatabase.InitializeAsync(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();

            app.UseHttpsRedirection();

            // Get cors to shut up
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
