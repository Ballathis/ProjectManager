using ProjectManager.Shared.Models;

namespace ProjectManager.Server.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllWithObjectAsync();
    }
}
