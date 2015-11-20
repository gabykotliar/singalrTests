using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.AspNet.SignalR;

using SRTest.SignalR;

namespace SRTest.Controllers.Api
{
    [RoutePrefix("/api/data")]
    public class DataController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<DashboardHub>();

            var tasks = new List<Task>();
            var random = new Random(DateTime.Now.Second);

            for (int widgetId = 1; widgetId < 10; widgetId++)
            {
                tasks.Add(Task.Factory.StartNew(data => {
                                                            var rn = random.Next(500, 1000);

                                                            Thread.Sleep(rn);

                                                            hub.Clients.All.widgetLoaded(new {
                                                                id = data,
                                                                delayed = rn
                                                            });
                                                        }, 
                                                 widgetId));                
            }            

            Task.WaitAll(tasks.ToArray());

            return Json(new
            {
                id = id
            });
        }
    }
}
