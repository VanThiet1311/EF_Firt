using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MiniEfApi.Data;
using MiniEfApi.Services;
using EF_CORE;
using EF_ENTITY;
using EF_BASE.RepositoryBase;

namespace MiniEfApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // EF Core + MySQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))
                )
            );

            services.AddScoped(typeof(IRepositoryBase<>), typeof(Repository<>));
            services.AddScoped(typeof(DomainService<>));
            services.AddScoped<CustomerService>();

            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                );
            });
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
