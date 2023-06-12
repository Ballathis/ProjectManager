using ProjectManager.Shared.Models;

namespace ProjectManager.Server.Data.Repositories.Interfaces
{
    public interface IDocumentationRepository
    {
        Task<List<DocumentationInfoFull>> GetDocumentationInfoFullByObjectIdAsync(int id);
        Task<List<DocumentationInfoFull>> GetDocumentationInfoFullByProjectIdAsync(int id);
        Task<bool> AddDocumentation(Documentation documentation);
    }
}
