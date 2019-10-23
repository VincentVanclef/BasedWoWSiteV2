using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using server.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpOverrides;
using server.Context.Realms.TitansLeague;
using server.Context.Realms.TwinkNation;
using server.Data.Realms;
using server.Data.Website;
using server.Services.SignalR;
using NetCore.AutoRegisterDi;
using server.Services.Ravendb;
using server.Services.SignalR.Chat;
using server.Util.Enums;

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
            services.Configure<RavenSettings>(Configuration.GetSection("Raven"));

            services.AddSingleton<IDocumentStoreHolder, DocumentStoreHolder>();

            // IP Security settings
            //services.Configure<IpSecuritySettings>(Configuration.GetSection("IpSecuritySettings"));

            //services.AddOptions();

            //// needed to store rate limit counters and ip rules
            //services.AddMemoryCache();

            ////load general configuration from appsettings.json
            //services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //// inject counter and rules stores
            //services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            //services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

            // other service configurations go here
            services.AddEntityFrameworkMySql()
                .AddDbContext<WebsiteContext>(options =>
                    options.UseLazyLoadingProxies().UseMySql(Configuration.GetConnectionString("WebsiteConnection")));

            services.AddEntityFrameworkMySql()
                .AddDbContext<AuthContext>(options =>
                    options.UseLazyLoadingProxies().UseMySql(Configuration.GetConnectionString("AuthConnection")));

            var realms = Configuration.GetSection("Realms").Get<Realm[]>();

            foreach (var realm in realms)
            {
                switch (realm.RealmType)
                {
                    case RealmType.TitansLeague:
                    {
                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TitansLeagueCharacterContext>(options =>
                                options.UseLazyLoadingProxies().UseMySql(realm.CharacterConnection));

                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TitansLeagueWorldContext>(options =>
                                options.UseLazyLoadingProxies().UseMySql(realm.WorldConnection));
                        }
                    break;
                    case RealmType.TwinkNation:
                    {
                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TwinkNationCharacterContext>(options =>
                                options.UseLazyLoadingProxies().UseMySql(realm.CharacterConnection));

                        services.AddEntityFrameworkMySql()
                            .AddDbContext<TwinkNationWorldContext>(options =>
                                options.UseLazyLoadingProxies().UseMySql(realm.WorldConnection));
                        }
                    break;
                    //case RealmType.MountOlympus:
                    //{
                    //    services.AddEntityFrameworkMySql()
                    //        .AddDbContext<MountOlympusCharacterContext>(options =>
                    //            options.UseLazyLoadingProxies().UseMySql(realm.CharacterConnection));
                    //        break;
                    //}
                    //case RealmType.Helios:
                    //{
                    //    services.AddEntityFrameworkMySql()
                    //        .AddDbContext<HeliosCharacterContext>(options =>
                    //            options.UseLazyLoadingProxies().UseMySql(realm.CharacterConnection));
                    //    break;
                    //}
                    default:
                        throw new ArgumentOutOfRangeException($"Realm type {realm} not supported!");
                }
            }

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

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<WebsiteContext>()
                .AddDefaultTokenProviders();

            var jwtKey = Configuration.GetSection("JWTKey")
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
                    LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = "Titans-League",
                    ValidIssuer = "Titans-League",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        if (string.IsNullOrEmpty(accessToken) == false)
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("91.121.121.227"));
            });

            services.AddSignalR();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Register Services
            services.RegisterAssemblyPublicNonGenericClasses(Assembly.Load(nameof(server)))
                .Where(x => x.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            // https://github.com/aspnet/Hosting/issues/793
            // the IHttpContextAccessor service is not registered by default.
            // the clientId/clientIp resolvers use it.
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //// configuration (resolvers, counter key builders)
            //services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseIpRateLimiting();
            //app.UseMiddleware<IpRestrictionMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Create Base User
            //SeedDatabase.InitializeAsync(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider).Wait();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // Get cors to shut up
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:8080"));

            app.UseSignalR(routes =>
            {
                routes.MapHub<SignalRHub>("/signalRHub");
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseMvc();
        }
    }
}
