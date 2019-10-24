namespace ShoppingList.Api
{
    using System;
    using AutoMapper;
    using Common;
    using Configuration;
    using Configuration.DependencyInjection;
    using Configuration.ErrorHandling;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using NLog;

    public class Startup
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                TryConfigureServices(services);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        private void TryConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerDocument();

            services.AddCors(o => o.AddPolicy(CorsPolicies.AllowAllPolicy, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.RegisterTypesByAttributes();

            services.AddMediatR(MyAssembly.Assemblies);
            services.AddAutoMapper(MyAssembly.Assemblies);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseCors(CorsPolicies.AllowAllPolicy);
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}