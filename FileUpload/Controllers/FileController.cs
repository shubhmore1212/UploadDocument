using FileUpload.Models;
using FileUpload.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IManageImage _iManageImage;

        public FileController(IManageImage iManageImage)
        {
            _iManageImage = iManageImage;     
        }

        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> UploadFile(IFormFile _IFormFile)
        {
            var result= await _iManageImage.UploadFileAsync(_IFormFile);
            return Ok(result);
        }

        [HttpGet]
        [Route("downloadfile")]
        public async Task<IActionResult> DownloadFile(string FileName)
        {
            var result = await _iManageImage.DownloadFileAsync(FileName);
            return File(result.Item1, result.Item2,result.Item3);
        }

        [HttpPost]
        [Route("student")]
        public async Task<IActionResult> CheckRequestBody([FromForm] Student student)
        {
            return Ok();
        }
    }
}
