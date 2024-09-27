using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FileTransferAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // Lista os arquivos e diretórios em um caminho
        [HttpGet("list")]
        public IActionResult ListDirectory([FromQuery] string path)
        {
            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path);
                var directories = Directory.GetDirectories(path);

                return Ok(new { files, directories });
            }

            return NotFound("Directory not found.");
        }

        // Faz o upload de arquivos
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File not selected");

            var filePath = Path.Combine("UploadedFiles", file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { FilePath = filePath });
        }

        // Faz o download de arquivos
        [HttpGet("download")]
        public IActionResult DownloadFile([FromQuery] string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            var bytes = System.IO.File.ReadAllBytes(filePath);
            var fileName = Path.GetFileName(filePath);

            return File(bytes, "application/octet-stream", fileName);
        }
    }
}

