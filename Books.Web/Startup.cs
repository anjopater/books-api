﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
//import your context to connect your services to your database connection string.
using Books.Data;
//import EntityFrameworkCore to connect your context options to your MySQL Database.
using Microsoft.EntityFrameworkCore;
//import your Books Repository and Books Service for dependency injection.
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

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Get your connection string from your Configuration object via the ConnectionStrings and DefaultConnection Key and value.
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            //Connect your services and repositories to your database.
            //1 By first add the DbContext as a generic type.
            //2 NOw have your options returned from the lambda to be useMySQl methond, and pass in your connection string to connect your database.
            services.AddDbContext<BooksContext>(options => options.UseMySql(connectionString));
            //We will perform depenency injection in our ConfigureServices method, and also connect to our database and context.
            //They are 4 levels of dependency injection.
            //Instance-You will have one static instance that can't be extended if needed be through out entire application.
            //Singleton-Will have one single instance that can be used throughout application.
            //Scoped-Will have a instance for an entire http request. It will go through controller -> service -> repository -> context
            //Transient-A new instance will be used for each method. It will be disposed after each method, and would be created again if needed
            //In this case we will just have a single scoped instance of our repository and service.
            //Use the AddScoped to add a signature and it's correpsonding class.
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IBooksService, BooksService>();
            //After you define your cors have your IServicePRovider instance use COrs.
            
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(origins: "*");
                });
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                //Have your CorsPolicyBuilder builder returned when your IApplicationBuilder instance uses cors have it use AnyHeader, AnyMethod, AnyOrigin, and AnyCredentials.
                builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
            });
            app.UseMvc();
            
        }
    }
}
