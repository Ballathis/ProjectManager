using Microsoft.AspNetCore.Identity;
using ProjectManager.Server.Data.Repositories;
using ProjectManager.Server.Data.Repositories.Interfaces;

namespace ProjectManager.Server.DI
{
    public static class DI
    {
        public static IServiceCollection AddDataLifetimes(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IDocumentationRepository, DocumentationRepository>();

            return services;
        }
    }
}
