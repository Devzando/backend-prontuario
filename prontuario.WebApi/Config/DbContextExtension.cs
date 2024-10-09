using Microsoft.EntityFrameworkCore;
using prontuario.Infra.Database;

namespace prontuario.WebApi.Config
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProntuarioDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
