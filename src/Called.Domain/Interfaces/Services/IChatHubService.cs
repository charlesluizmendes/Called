using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Called.Domain.Interfaces.Services
{
    public interface IChatHubService
    {
        Task SendMessageAsync(string usuario, string mensagem);
    }
}
