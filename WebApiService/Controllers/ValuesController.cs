using CommunicationContracts;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiService.Controllers
{
  [RoutePrefix("api")]
  public class ValuesController : ApiController
  {
    [Route("get-actor-ids")]
    public async Task<string> GetRunningCustomActorIdsAsync()
    {
      ICustomActorServiceApi proxy = ServiceProxy.Create<ICustomActorServiceApi>(
        new Uri("fabric:/CustomActorServiceApp/CustomActorService"), 
        new ServicePartitionKey(1));

      return await proxy.GetRunningCustomActorIdsAsync();
    }
  }
}
