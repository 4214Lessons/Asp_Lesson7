using Lesson7.EfCore.Data.Repositories;
using Lesson7.EfCore.Models;

namespace Lesson7.EfCore.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Car>, Repository<Car>>();
            services.AddTransient<IRepository<Driver>, Repository<Driver>>();
        }
    }
}
