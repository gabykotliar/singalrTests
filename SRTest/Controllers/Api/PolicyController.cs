using System.Threading;
using System.Web.Http;

using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

using SRTest.SignalR;

namespace SRTest.Controllers.Api
{
    [RoutePrefix("/api/policy")]
    public class PolicyController : ApiController
    {
        public IHttpActionResult Get(int id)
        {

            var data = $"widget 1 para policyId {id}";

            var hub = GlobalHost.ConnectionManager.GetHubContext<PolicyEditionHub>();

            for (int widgetId = 1; widgetId < 10; widgetId++)
            {
                Thread.Sleep(500);
                hub.Clients.All.widgetLoaded(widgetId);
            }

            return Json(new
            {
                id = id,
                branchId = 200,
                productId = 99
            });
        }
    }
}
//DefaultHubManager hd = new DefaultHubManager(GlobalHost.DependencyResolver);

//var hub3 = hd.ResolveHub("policySequence") as PolicyEditionHub;

//hub3?.SendWidgetInfo(data);