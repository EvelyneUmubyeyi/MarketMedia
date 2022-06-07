using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using MarketMedia.src.EF;
using Microsoft.EntityFrameworkCore;
using MarketMedia.src.Services;
using System.Text.Json.Serialization;

namespace MarketMedia
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
            services.AddDbContext<MMDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddControllers().AddJsonOptions(options => {
            // Ignore self reference loop
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            }); 
            services.AddCors();
            services.AddScoped<IRepository,Repository>();

            // Adding code of swagger 
            services.AddSwaggerGen(c =>
            {
                //  c.DocumentFilter<XLogoDocumentFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TPT API",
                    Description = "Tigersoft Product Training Api 1.0 ",
                    TermsOfService = new Uri("http://www.tigersoft.rw"),
                    Contact = new OpenApiContact() { Name = "Tigersoft", Email = "Umubyeyievelyne8917@gmail.com", Url = new Uri("http://www.tigersoft.rw") }
                });

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
              options => options.WithOrigins(
                "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseAuthentication();
            app.UseRouting();

            // adding swager code for api

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });
            app.UseSwagger(o =>
            {
                o.RouteTemplate = "dev/{documentName}/dev.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.EnableDeepLinking();
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
                c.DisplayRequestDuration();
                c.DocumentTitle = "TPC Api 1.0";
                c.RoutePrefix = "dev";
                c.SwaggerEndpoint("/dev/v1/dev.json", "Market Media Api");
                c.InjectStylesheet("/css/custom.css");
                c.InjectJavascript("/js/custom.js");
            });

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async ctx =>
                {
                    await ctx.Response.WriteAsync("welcome to Tigersoft product training TPT");
                });
            });


        }
    }
}
