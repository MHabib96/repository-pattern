using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RepositoryPattern.Database;
using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Abstracts;
using RepositoryPattern.Repositories.Interfaces;
using RepositoryPattern.UnitOfWork.Interfaces;

namespace RepositoryPattern
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
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "RepositoryPattern", Version = "v1"});
            });

            //Database Contexts.
            services.AddDbContext<PlaygroundContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("PlaygroundConnection"),
                    b => b.MigrationsAssembly(typeof(PlaygroundContext).Assembly.FullName)));
            
            //Repositories.
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            
            //Unit of Work.
            services.AddTransient<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RepositoryPattern v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}