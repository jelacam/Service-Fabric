using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Data.Collections;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using ServiceContracts;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;

namespace WcfStatefulService
{
    /// <summary>
    /// An instance of this class is created for each service replica by the Service Fabric runtime.
    /// </summary>
    internal sealed class WcfStatefulService : StatefulService
    {
        public WcfStatefulService(StatefulServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., HTTP, Service Remoting, WCF, etc.) for this service replica to handle client or user requests.
        /// </summary>
        /// <remarks>
        /// For more information on service communication, see https://aka.ms/servicefabricservicecommunication
        /// </remarks>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceReplicaListener> CreateServiceReplicaListeners()
        {
            return new List<ServiceReplicaListener>()
            {
                new ServiceReplicaListener(context => CreateHelloCommunicationListener(context), "HelloEndpoint"),
                new ServiceReplicaListener(context => CreateHiCommunicationListener(context), "HiEndpoint")
            };
        }

        private ICommunicationListener CreateHelloCommunicationListener(StatefulServiceContext context)
        {
            var listener = new WcfCommunicationListener<IHelloContract>(
                wcfServiceObject: new Hello(),
                serviceContext: context,
                endpointResourceName: "HelloEndpoint",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
            return listener;
        }

        private ICommunicationListener CreateHiCommunicationListener(StatefulServiceContext context)
        {
            var listener = new WcfCommunicationListener<IHiContract>(
                wcfServiceObject: new Hi(),
                serviceContext: context,
                endpointResourceName: "HiEndpoint",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
            return listener;
        }
    }
}