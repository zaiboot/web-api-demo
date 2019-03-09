using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserProjects.DAL;
using UserProjects.DAL.Context;
using UserProjects.DAL.Repositories;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
             var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Configuration.json", optional: false, reloadOnChange: true);

            builder.AddEnvironmentVariables();
            _configuration = builder.Build();
        }

       private readonly IConfigurationRoot _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddTransient<IMapper, Mapper>();
            services.AddOptions();
            //  Add framework services.
            var cnx = _configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<UserProjectsDataContext>(options =>
            {
                options.UseSqlServer(cnx);
            });
            var builder = new ContainerBuilder();
            builder.Populate(services);
            AddAutofacRegistrations(builder);
            var container = builder.Build();
        }

        private void AddAutofacRegistrations(ContainerBuilder builder)
        {
           builder.RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

        #region REPOSITORY

            builder.RegisterType<UserProjectsDataContext>().As<IDataContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(
                Assembly.GetAssembly(typeof(UserRepository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            
        #endregion

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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
