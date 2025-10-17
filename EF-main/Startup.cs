using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using MiniEfApi.Data;

namespace MiniEfApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // add service vào DI container
        public void ConfigureServices(IServiceCollection services)
        {
            // 1️⃣ EF Core + MySQL
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 33)) // đổi version MySQL theo máy bạn
                )
            );

            // 2️⃣ Controllers
            services.AddControllers();
        }

        // Cấu hình middleware pipeline
        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Xác thực/ủy quyền (nếu có)
            app.UseAuthorization();

            // Map các controller route
            app.MapControllers();
        }
    }
}
