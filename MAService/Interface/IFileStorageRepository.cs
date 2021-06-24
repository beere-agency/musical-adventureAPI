using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MAService.Interface
{
    public interface IFileStorageRepository
    {
        Task DeleteFile(string fileRoute, string containerName);
        Task<string> EditFile(string containerName, IFormFile file, string fileRoute);
        Task<string> SaveFile(string containerName, IFormFile file);
    }
}