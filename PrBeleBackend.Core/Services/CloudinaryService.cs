using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using PrBeleBackend.Core.ServiceContracts;

namespace PrBeleBackend.Core.Services
{
    public class CloudinaryService : ICloudinaryContract
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folder, int width, int height)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = "bele/" + folder,
                Transformation = new Transformation().Crop("fill").Width(width).Height(height)
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if(uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl?.ToString();
            }
            else
            {
                throw new ArgumentNullException("Upload image fail!");
            }
        }
    }
}
