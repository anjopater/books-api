using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Books.Data;
using Microsoft.EntityFrameworkCore;
using Books.Data.Repositories.Books;
using Books.Data.Repositories.Books.Impl;
using Books.Services.Services.Books;
using Books.Services.Services.Books.Impl;
using Books.Data.Seeds;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace Books.Web
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
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<BooksContext>(options => options.UseMySql(connectionString));
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksService, BooksService>();
            
            services.AddCors();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Books API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Description = "A simple example ASP.NET Core Web API",
                    Contact = new OpenApiContact
                    {
                        Name = "Antonio",
                        Email = string.Empty,
                        Url = new Uri("https://paterninaisf.github.io"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://paterninaisf.github.io"),
                    }
                });
            });
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BooksContext context)
        {
            EnsureBooksData.Seed(context);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Books API V1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
