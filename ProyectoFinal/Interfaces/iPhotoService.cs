using CloudinaryDotNet.Actions;

namespace ProyectoFinal.Interfaces
{
    public interface iPhotoService
    {
        Task<ImageUploadResult> AddPhotosAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
