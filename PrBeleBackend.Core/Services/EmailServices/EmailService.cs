using PrBeleBackend.Core.ServiceContracts.EmailContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PrBeleBackend.Core.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Thông tin tài khoản gửi email
            var fromEmail = _configuration["NetMail:Email"];
            var fromPassword = _configuration["NetMail:Password"];
            

            // Cấu hình SMTP Client
            using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpClient.EnableSsl = true; // Sử dụng SSL

                // Tạo email
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Nếu email có HTML
                };

                mailMessage.To.Add(toEmail);

                // Gửi email
                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
