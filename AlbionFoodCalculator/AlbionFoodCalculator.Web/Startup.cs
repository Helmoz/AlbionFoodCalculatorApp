using AlbionFoodCalculator.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AlbionFoodCalculator.Services;
using Microsoft.AspNetCore.HttpOverrides;
using System;
using GraphQL.Server;
using AlbionFoodCalculator.GQL.GraphQLSchema;
using GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using AlbionFoodCalculator.GQL.Types;
using AlbionFoodCalculator.GraphQL.Types;
using GraphQL.Types;

namespace AlbionFoodCalculator.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; }); ;
            services
                .AddHttpsRedirection(options => { options.HttpsPort = 443; })
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            services.AddMemoryCache();
            services.AddDbContext<ApplicationDbContext>(options => options.UseLazyLoadingProxies()
                                                                          .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<FoodItemPriceService>();

            services.AddScoped<FoodItemType>();
            services.AddScoped<HistoryType>();
            services.AddScoped<FoodItemResourceType>();

            services.AddScoped<ULongGraphType>();
            services.AddScoped<DecimalGraphType>();
            services.AddScoped<DateTimeGraphType>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<AppSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = true; }).AddGraphTypes(ServiceLifetime.Scoped);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
                using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DYNO")))
            {
                Console.WriteLine("Use https redirection");
                app.UseHttpsRedirection();
            }

            app.UseGraphQL<AppSchema>();

            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            if (env.IsDevelopment())
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    spa.UseProxyToSpaDevelopmentServer($"http://localhost:8080");
                });
            }
        }
    }
}
