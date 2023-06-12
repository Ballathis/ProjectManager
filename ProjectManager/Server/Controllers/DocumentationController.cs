using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Server.Data.Repositories.Interfaces;
using ProjectManager.Server.Data;
using Microsoft.Extensions.Logging;
using ProjectManager.Shared.Models;

namespace ProjectManager.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentationController : ControllerBase
    {
        private readonly ILogger<DocumentationController> _logger;
        private readonly IProjectRepository _projectRepository;
        private readonly IDocumentationRepository _documentationRepository;
        public DocumentationController(
            ILogger<DocumentationController> logger,
            IProjectRepository projectRepository, 
            IDocumentationRepository documentationRepository)
        {
            this._logger = logger;
            this._projectRepository = projectRepository;
            this._documentationRepository = documentationRepository;
        }

        [HttpGet("GetAllProject")]
        public async Task<IActionResult> GetAllProject()
        {
            try
            {
                return Ok(await _projectRepository.GetAllWithObjectAsync());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDocumentationInfoFullByObject")]
        public async Task<IActionResult> GetDocumentationInfoFullByObject(int id)
        {
            try
            {
                return Ok(await _documentationRepository.GetDocumentationInfoFullByObjectIdAsync(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetDocumentationInfoFullByProject")]
        public async Task<IActionResult> GetDocumentationInfoFullByProject(int id)
        {
            try
            {
                return Ok(await _documentationRepository.GetDocumentationInfoFullByProjectIdAsync(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPost("AddDocumentation")]
        public async Task<IActionResult> AddDocumentation([FromBody] Documentation documentation)
        {
            try
            {
                return Ok(await _documentationRepository.AddDocumentation(documentation));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}