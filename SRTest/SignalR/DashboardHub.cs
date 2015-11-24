using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

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

        public void Load(int policyId)
        {
            var tasks = new List<Task>();
            var random = new Random(DateTime.Now.Second);

            for (int widgetId = 1; widgetId < 10; widgetId++)
            {
                tasks.Add(Task.Factory.StartNew(data => {
                    var rn = random.Next(2000, 4000);

                    Thread.Sleep(rn);

                    Clients.Caller.widgetLoaded(new
                    {
                        id = data,
                        delayed = rn
                    });
                },
                widgetId));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}