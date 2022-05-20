using MaximoFarm.Register.Api.Data;
using MaximoFarm.Register.Api.Ioc;
using MaximoFarm.Register.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MaximoFarm.Register.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaximoFarm.Register.Api", Version = "v1" }));
            services.AddDbContext<RegisterContext>(
                options => options.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("MaximoFarm.Register.Api")));
            services.AddDbContext<ApplicationContext>(
                options => options.UseNpgsql(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddStackExchangeRedisCache(options => 
            {
                options.InstanceName = "redis";
                options.Configuration = "localhost:6379";
            });

            services.AddMediatR(typeof(Startup));

            services.RegisterServices();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de cadastros v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
