using Microsoft.AspNetCore.Http;

namespace EShop.Services
{
    public interface IBufferedFileUploadService
    {
        Task<(string, string)> UploadFile(IFormFile file);
    }

    public class BufferedFileUploadLocalService : IBufferedFileUploadService
    {
        

        public async Task<(string, string)> UploadFile(IFormFile file)
        {
            string path = "/";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot", "dist", "img"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    
                    return (path, file.FileName);
                }
                else
                {
                    return (null, null);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
