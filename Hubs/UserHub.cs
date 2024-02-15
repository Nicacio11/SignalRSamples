using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRSample.Hubs
{
    public class UserHub : Hub
    {
        public static int TotalViews { get; set; } = 0;

        public async Task NewWindowLoaded()
        {
            TotalViews++;
            await Clients.All.SendAsync("updateTotalViews", TotalViews);
        }
    }
}