using BackendTask.Business.Contracts;
using BackendTask.Business.Services;
using BackendTasks.Entity.Contracts;
using BackendTasks.Entity.Contracts.Repositories;
using BackendTasks.Entity.Services;
using BackendTasks.Entity.Services.Context;
using BackendTasks.Entity.Services.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BackendTask.API
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
            services.AddSwaggerGen(c => c.SwaggerDoc(name: "V1", new OpenApiInfo { Title = "Backend Task API", Version = "v1" }));

            MongoDbBsonSerializer.Configure();

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/V1/swagger.json", "Api"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Private methods
        private void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAdviserService, AdviserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAdviserRepository, AdviserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMongoContext, MongoContext>();
        }
        #endregion
    }
}
