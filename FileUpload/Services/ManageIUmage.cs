using FileUpload.Helper;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.AccessControl;

namespace FileUpload.Services
{
    public class ManageIUmage : IManageImage
    {
        public async Task<string> UploadFileAsync(IFormFile _IFormFile)
        {
            string fileName = "";
            try
            {
                FileInfo _FileInfo = new FileInfo(_IFormFile.FileName);
                fileName = _IFormFile.FileName + "_" + DateTime.Now.Ticks.ToString() + _FileInfo.Extension;
                byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    await _IFormFile.CopyToAsync(memoryStream);
                    bytes= memoryStream.ToArray();
                }

                var _GetFilePath = Common.GetFilePath(fileName);
                using (var _FileStream = new FileStream(_GetFilePath, FileMode.Create))
                {
                    await _IFormFile.CopyToAsync(_FileStream);
                }
                return fileName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<(byte[], string, string)> DownloadFileAsync(string FileName)
        {
            try
            {
                var _GetFilePath = Common.GetFilePath(FileName);
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(_GetFilePath, out var _ContentType))
                {
                    _ContentType = "application/octet-stream";
                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(_GetFilePath);
                return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(_GetFilePath));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
