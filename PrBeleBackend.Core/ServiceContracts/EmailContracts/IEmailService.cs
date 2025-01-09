using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrBeleBackend.Core.ServiceContracts.EmailContracts
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string body);

    }
}
