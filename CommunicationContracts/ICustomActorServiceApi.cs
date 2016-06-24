using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationContracts
{
  public interface ICustomActorServiceApi : Microsoft.ServiceFabric.Services.Remoting.IService
  {
    Task<string> GetRunningCustomActorIdsAsync();
  }
}
