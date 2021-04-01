using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using DelVeggieAPI.Models;
using DelVeggieAPI.BusinessLayer;
using Microsoft.Extensions.Options;

namespace DelVeggieAPI
{
    public class Startup
    {
        readonly string AllowLocalhost = "_allowLocalHost";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        services.AddCors(options =>
        {
            options.AddPolicy(name: AllowLocalhost,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:4200");
                              });
        });
            services.AddControllers();
            services.AddScoped<IVeggieService,VeggieService>();
            services.Configure<DeliVeggieDatabaseSettings>(Configuration.GetSection(nameof(DeliVeggieDatabaseSettings)));
            services.AddSingleton<IDeliVeggieDatabaseSettings>(sp=>sp.GetRequiredService<IOptions<DeliVeggieDatabaseSettings>>().Value);   
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DelVeggieAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DelVeggieAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowLocalhost);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
