using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts
{
    public interface ICloudinaryService
    {
        public Task<string> UploadImageAsync(IFormFile file, string imgType);
    }
}
