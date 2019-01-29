using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Infrastructure;
using Northwind.Application.Infrastructure.AutoMapper;
using Northwind.Application.Interfaces;
using Northwind.Application.Rooms.Commands.CreateRoom;
using Northwind.Application.Rooms.Models;
using Northwind.Application.Rooms.Queries.GetRooms;
using Northwind.Application.Rooms.Services;
using Northwind.Common;
using Northwind.Infrastructure;
using Northwind.Persistence;
using Northwind.WebUI.Filters;
using NSwag.AspNetCore;
using System.Reflection;

namespace Northwind.WebUI
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetRoomsQuery).GetTypeInfo().Assembly);

            // Add DbContext using SQL Server Provider
            //services.AddDbContext<NorthwindDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("NorthwindDatabase")));

            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("RoomDatabase")));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
                //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRoomCommand>());

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Conference Rooms API";
                    document.Info.Description = "A simple ASP.NET core web API";
                };
            }
            );

            services.AddTransient<IEmailService, EmailService>();

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
