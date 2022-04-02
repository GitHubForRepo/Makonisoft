using DataAccess;
using FeatureObject;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace DependencyResolver
{
    public static class ServiceConfig
    {
        public static void ConfigureFeatureObjects(this IServiceCollection services)
        {
            services.AddScoped<IUserDetails, UserDetails>();
            services.AddSingleton(Download.Create(GetFilePath()));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton(GetDataStore());
        }

        private static IDataStore GetDataStore()
        {
            var fullPath = GetFilePath();
            if (!File.Exists(fullPath))
                using (File.Create(fullPath)) ;
            return FileStore.Create(fullPath);
        }

        private static string GetFilePath()
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory());
            return Path.Combine(pathToSave, "Data.json");

        }
    }
}
