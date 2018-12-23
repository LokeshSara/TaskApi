using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskApi.Entity;
using TaskApi.repository;
using AutoMapper;
using TaskApi.Model;

namespace TaskApi
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<ITaskManagerRepository, TaskManager>();
            services.AddScoped<IProjectRepository, repository.Project>();
            services.AddScoped<IUserRepository, repository.User>();

            services.AddDbContext<TaskDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

          

            string[] origins = new string[] { "http://suchi-pc/", "http://localhost:4200/" };

            app.UseCors(builder =>
                 builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseMvc();

        }
    }
}
