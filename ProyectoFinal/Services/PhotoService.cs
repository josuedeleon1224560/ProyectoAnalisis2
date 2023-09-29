using Microsoft.Extensions.Options;
using ProyectoFinal.helpers;
using CloudinaryDotNet;
using ProyectoFinal.Interfaces;
using System.Security.Principal;
using CloudinaryDotNet.Actions;
using System.IO;
using System;

namespace ProyectoFinal.Services
{
    public class PhotoService : iPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(IOptions<CloudinaySettings> config) 
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<ImageUploadResult> AddPhotosAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if(file != null && file.Length>0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

    }
}
