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
using Microsoft.Extensions.Logging;
using UserProjects.Common.Mapping;
using UserProjects.DAL;
using UserProjects.DAL.Context;
using UserProjects.DAL.Repositories;

namespace Web.Api
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


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
            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins,
                    corsPolicyBuilder =>
                    {
                        corsPolicyBuilder.AllowAnyOrigin();
                        corsPolicyBuilder.WithMethods("GET");
                    });
 
            });


            //  Add framework services.
            var cnx = _configuration.GetValue<string>("ConnectionString");
            services.AddDbContext<UserProjectsDataContext>(options =>
            {
                options.UseSqlServer(cnx);
            });
            services.AddTransient<IMapper, Mapper>();
            services.AddOptions();
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            AddAutofacRegistrations(builder);
            var container = builder.Build();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            AddAutofacRegistrations(builder);
        }
        private void AddAutofacRegistrations(ContainerBuilder builder)
        {
           builder.RegisterAssemblyTypes(
                    Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

        #region REPOSITORY

            builder.RegisterType<UserProjectsDataContext>().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(
                Assembly.GetAssembly(typeof(UserRepository)))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            
        #endregion
        
            builder.Register(ctx =>
            {
                var logger = ctx.Resolve<ILogger<MappingEngine>>();

                var assemblies = new[]
                {
                    Assembly.GetAssembly(typeof(UserRepository)),
                    Assembly.GetExecutingAssembly()
                };
                return new MappingEngine(assemblies, logger);
            }).As<IMappingEngine>().InstancePerLifetimeScope();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(MyAllowSpecificOrigins); 
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
            loggerFactory
                .AddLog4Net();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
