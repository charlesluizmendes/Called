using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attemdance.Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(string from, string to, string subject, string html);
    }
}
