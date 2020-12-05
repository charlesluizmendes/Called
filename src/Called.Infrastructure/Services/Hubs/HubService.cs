using Called.Domain.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Called.Infrastructure.Services.Hubs
{
    public class HubService : IHubService
    {
        private readonly IHubContext<Hub> _hub;

        public HubService(IHubContext<Hub> hub)
        {
            _hub = hub;
        }

        public async Task SendMessageAsync(string usuario, string mensagem)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", usuario, mensagem);
        }
    }
}
