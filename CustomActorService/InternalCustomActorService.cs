using CustomActorService.Interfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Query;
using Microsoft.ServiceFabric.Actors.Runtime;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomActorService
{
  internal sealed class InternalCustomActorService : ActorService
  {
    public InternalCustomActorService(
      StatefulServiceContext context, 
      ActorTypeInformation actorTypeInfo, 
      Func<ActorBase> actorFactory = null, 
      IActorStateProvider stateProvider = null, 
      ActorServiceSettings settings = null) 
        : base(context, actorTypeInfo, actorFactory, stateProvider, settings)
    {
    }


    protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
    {
      var remotingListener = new ServiceReplicaListener(context => this.CreateServiceRemotingListener(context));
      return new ServiceReplicaListener[] { remotingListener };
    }


    protected async override Task RunAsync(CancellationToken cancellationToken)
    {
      await base.RunAsync(cancellationToken);

      for(int i = 0; i < 10; i++)
      {
        ICustomActor proxy = ActorProxy.Create<ICustomActor>(new ActorId(i));
        await proxy.StartAsync();
      }
    }
  }
}
