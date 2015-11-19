using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SRTest.SignalR
{
    [HubName("policySequence")]
    public class PolicyEditionHub : Hub
    {
        public void SendWidgetInfo(string widget)
        {
            Clients.All.widgetLoaded(widget);
        }
    }
}