using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class FileController : ControllerBase
    {
        private readonly IFileBusiness _business;

        public FileController(IFileBusiness business)
        {
            _business = business;
        }

        [HttpPost("uploadFile")]
        [ProducesResponseType((200), Type = typeof(FileDetailVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
        {
            FileDetailVO detail = await _business.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }

        [HttpPost("uploadMultiPartFile")]
        [ProducesResponseType((200), Type = typeof(List<FileDetailVO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> UploadManyFiles([FromForm] List<IFormFile> file)
        {
            List<FileDetailVO> detail = await _business.SaveFileToDisk(file);
            return new OkObjectResult(detail);
        }

        [HttpGet("downloadFile/{fileName}")]
        [ProducesResponseType((200), Type = typeof(List<FileDetailVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Produces("application/json")]
        public async Task<IActionResult> GetFileAsync(string fileName)
        {
            byte[] buffer = _business.GetFile(fileName);
            if (buffer != null)
            {
                HttpContext.Response.ContentType =
                    $"application/{Path.GetExtension(fileName).Replace(".", "")}";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
            }

            return new ContentResult();
        }
    }
}
