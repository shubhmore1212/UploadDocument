namespace FileUpload.Services
{
    public interface IManageImage
    {
        Task<string> UploadFileAsync(IFormFile _IFormFile);
        Task<(byte[], string, string)> DownloadFileAsync(string FileName);
    }
}
