using Microsoft.EntityFrameworkCore;
using ProjectManager.Server.Data.Repositories.Interfaces;
using ProjectManager.Shared.Models;

namespace ProjectManager.Server.Data.Repositories
{
    public class DocumentationRepository : IDocumentationRepository
    {
        private readonly ApplicationDbContext _context;
        public DocumentationRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<DocumentationInfoFull>> GetDocumentationInfoFullByObjectIdAsync(int id)
        {
            return await _context.Documentations.Where(x => x.IdDesignObject == id)
                .Include(x=>x.DesignObject.DesignObjectsParent)
                .Select(d => new DocumentationInfoFull()
                {
                    ProjectCode = d.DesignObject.Project.Code,
                    ObjectCode = d.DesignObject.FullCode,
                    Mark = new Mark() { Id = d.Mark.Id, Name = d.Mark.Name, ShortName = d.Mark.ShortName },
                    DocumentationNumber = d.Number,
                    FullCode = $"{d.DesignObject.Project.Code}-{d.DesignObject.FullCode}-{d.Mark.ShortName}{d.Number}"
                }).ToListAsync();
        }
    }
}
