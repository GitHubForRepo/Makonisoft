using DataAccess;
using FeatureObject;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DependencyResolver
{
    public static class ServiceConfig
    {
        public static void ConfigureFeatureObjects(this IServiceCollection services)
        {
            services.AddScoped<IUserDetails, UserDetails>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton(GetDataStore());
        }

        private static IDataStore GetDataStore()
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory());
            var fullPath = Path.Combine(pathToSave,  "Data.json");
            if (!File.Exists(fullPath))
                using (File.Create(fullPath));
            return FileStore.Create(fullPath);
            }
    }
}
