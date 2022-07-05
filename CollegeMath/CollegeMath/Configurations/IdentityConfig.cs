using CollegeMath.Data;
using Microsoft.EntityFrameworkCore;

namespace CollegeMath.Configurations
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CollegeMathConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
