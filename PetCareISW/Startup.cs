using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PetCareISW.DataAccess;
using PetCareISW.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCareISW
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
            services.AddInjection();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(@"Server=LAPTOP-6QJ5S582\MSSQLSERVER01; Database=PetCareISW; Integrated Security=true;");
                // JOAQUIN CONNECTION
                //options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;");

                //
                //optionsBuilder.UseSqlServer(@"Server = DESKTOP-44K5N6D\MSSQLSERVER2;Database=PetCareISW;Integrated Security=true;");


                //  
                // options=>options.UseMySQL("Server=localhost;userid=root;Password=root;Database=PetCareISW"));
                //options.UseSqlServer(@"Data Source=DESKTOP-NRGUKED;Initial Catalog=EcommerceDb;Integrated Security=True");
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PetCareAPI", Version = "v1" });
            });

            services
                .AddHttpsRedirection(options => { options.HttpsPort = 443; })
                .AddMvcCore()
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });

            services.AddHttpsRedirection(options => { options.HttpsPort = 443; });
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetCareISW v1"));
            }

            //app.UseHttpsRedirection();

            /*app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/

            /*if (env.IsProduction())
            {
                app
                    .UseForwardedHeaders()
                    .UseHttpsRedirection();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetCareISW v1"));
            }*/

            app.UseForwardedHeaders();
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DYNO")))
            {
                Console.WriteLine("Use https redirection");
                app.UseHttpsRedirection();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetCareISW v1"));
            }
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
