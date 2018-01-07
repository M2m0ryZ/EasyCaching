﻿namespace EasyCaching.Demo.Interceptor
{
    using System;
    using EasyCaching.Core;
    using EasyCaching.Demo.Interceptor.Services;
    using EasyCaching.Extensions;
    using EasyCaching.InMemory;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IEasyCachingProvider,InMemoryCachingProvider>();
            services.AddScoped<IDateTimeService,DateTimeService>();

            return services.ConfigureEasyCaching();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
