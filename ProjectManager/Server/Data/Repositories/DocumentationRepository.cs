using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Server.Controllers;
using ProjectManager.Server.Data.Repositories.Interfaces;
using ProjectManager.Shared.Models;
using System.Runtime.Intrinsics.Arm;

namespace ProjectManager.Server.Data.Repositories
{
    public class DocumentationRepository : IDocumentationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DocumentationRepository> _logger;
        public DocumentationRepository(
            ApplicationDbContext context,
            ILogger<DocumentationRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }
        public async Task<List<DocumentationInfoFull>> GetDocumentationInfoFullByObjectIdAsync(int id)
        {
            return await _context.Documentations.Where(x => x.IdDesignObject == id)
                .Include(x=>x.DesignObject.DesignObjectsParent)
                .Select(d => new DocumentationInfoFull()
                {
                    ProjectCode = d.DesignObject.Project.Code,
                    ObjectCode = d.DesignObject.FullCode,
                    Mark = new Shared.Models.Mark() { Id = d.Mark.Id, Name = d.Mark.Name, ShortName = d.Mark.ShortName },
                    DocumentationNumber = d.Number,
                    FullCode = $"{d.DesignObject.Project.Code}-{d.DesignObject.FullCode}-{d.Mark.ShortName}{d.Number}"
                }).ToListAsync();
        }
        public async Task<List<DocumentationInfoFull>> GetDocumentationInfoFullByProjectIdAsync(int id)
        {
            return await _context.Documentations.Where(x=>x.DesignObject.IdProject == id)
                .Include(x => x.DesignObject.DesignObjectsParent)
                .Select(d => new DocumentationInfoFull()
                {
                    ProjectCode = d.DesignObject.Project.Code,
                    ObjectCode = d.DesignObject.FullCode,
                    Mark = new Shared.Models.Mark() { Id = d.Mark.Id, Name = d.Mark.Name, ShortName = d.Mark.ShortName },
                    DocumentationNumber = d.Number,
                    FullCode = $"{d.DesignObject.Project.Code}-{d.DesignObject.FullCode}-{d.Mark.ShortName}{d.Number}"
                }).ToListAsync();
        }
        public async Task<bool> AddDocumentation(Documentation documentation)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var DocumentationCounter = await _context.DocumentationsCounter.FirstOrDefaultAsync(x => x.IdDesignObject == documentation.IdDesignObject);
                    int Counter = 0;
                    if (DocumentationCounter != null)
                    {
                        Counter = DocumentationCounter.DocumentationCount += 1;
                    }
                    int? maxCountUse = await _context.Documentations.Where(x => x.IdDesignObject == documentation.IdDesignObject).MaxAsync(x => x.Number);
                    if (maxCountUse is not null && maxCountUse >= Counter)
                    {
                        //warning 
                        _logger.LogWarning("Number in Documentations is larger than Counter in DocumentationsCounter");
                        Counter = (int)++maxCountUse;
                    }
                    documentation.Number = Counter;

                    await _context.Documentations.AddAsync(new()
                    {
                        IdDesignObject = documentation.IdDesignObject,
                        IdMark = documentation.IdMark,
                        Number = documentation.Number,
                    });
                    if (DocumentationCounter is not null)
                    {
                        DocumentationCounter.DocumentationCount = Counter;
                    }
                    else
                    {
                        await _context.DocumentationsCounter.AddAsync(new() { IdDesignObject = documentation.IdDesignObject, DocumentationCount = Counter });
                    }


                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number != 2627) // Violating unique constraint
                        throw;
                    _logger.LogWarning("AddDocumentation: Violating unique constraint");
                }
            }
            return false;
        }
    }
}
