using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SRTest.SignalR
{
    [HubName("dashboard")]
    public class DashboardHub : Hub
    {
        public void SendWidgetInfo(string widget)
        {
            Clients.All.widgetLoaded(widget);
        }
    }
}