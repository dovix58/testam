using Collibri.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Controllers
{
    [ApiController]
    [Route("/v1/files/{postId}")]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost("")]
        public IActionResult CreateFile([FromForm] IFormFile file, string postId)
        {
            var result = _fileRepository.CreateFile(file, postId);
            return result == null ? Conflict("File with this name already exists") : Ok(result);
        }

        [HttpDelete("{fileName}")]
        public IActionResult DeleteFile(string fileName, string postId)
        {
            var result = _fileRepository.DeleteFile(fileName, postId);
            return result == null ? Conflict("File does not exist") : Ok(result);
        }
	
        [HttpGet("{fileName}")]
        public IActionResult GetFile(string fileName, string postId)
        {
            var result = _fileRepository.GetFile(fileName, postId);
            return result == null ? Conflict("File does not exist") : Ok(result);
        }

        [HttpPut("{fileName}/{updatedName}")]
        public IActionResult UpdateFileName(string fileName, string postId, string updatedName)
        {
            var result = _fileRepository.UpdateFileName(fileName, postId, updatedName);
            return result == null ? Conflict("File does not exist") : Ok(result);
        }
    }
}