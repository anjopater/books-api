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
            app.UseMvc();
            
        }
    }
}
