using Attemdance.Domain.Interfaces.Services;
using Attemdance.Infrastructure.Service.Options;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Infrastructure.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailService(IOptions<EmailConfiguration> emailOptions)
        {
            _smtpHost = emailOptions.Value.SmtpHost;
            _smtpPort = emailOptions.Value.SmtpPort;
            _smtpUser = emailOptions.Value.SmtpUser;
            _smtpPass = emailOptions.Value.SmtpPass;
        }

        public async Task SendAsync(string from, string to, string subject, string html)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_smtpHost, _smtpPort, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_smtpUser, _smtpPass);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }                
        }
    }
}
