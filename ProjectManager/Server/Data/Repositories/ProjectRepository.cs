using ProjectManager.Shared.Models;
using ProjectManager.Server.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Server.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Project>> GetAllWithObjectAsync()
        {
            return await _context.Projects.Select(x => new Project()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                DesignObjects = GetDesignObjectsWithChildById( null, _context.DesignObjects.Where(d => d.IdProject == x.Id).AsNoTracking().ToList())
            }).ToListAsync();
        }
        private static List<DesignObject> GetDesignObjectsWithChildById(int? Id, List<Entities.DesignObject> designObjects)
        {
            return designObjects.Where(x => x.IdParent == Id)
                .Select(x => new DesignObject()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    IdParent = x.IdParent,
                    IdProject = x.IdProject,
                    //DesignObjectsParent = x.DesignObjectsParent,
                    DesignObjectsChild = GetDesignObjectsWithChildById(x.Id, designObjects)
                }).ToList();
        }
    }
}
