using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System.ServiceModel;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Runtime;
using ServiceContracts;
using System.Globalization;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace WcfService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class WcfService : StatelessService
    {
        public WcfService(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            //yield return new ServiceInstanceListener(context => this.CreateWcfCommunicationListener(context));
            return new List<ServiceInstanceListener>()
            {
                // Name parametar ServiceInstanceListener konstruktora moze biti bilo sta (ne mora biti isti kao name za endpoint)
                // samo ne sme biti prazan string - verovatno je to default
                // tako da ako se koristi jedan listener moze kao prethodno sa yield ... ili kao lista koja vraca jedan ServiceInstanceListener
                // ako se koristi vise Listenera onda se mora setovati Name parametar
                new ServiceInstanceListener(context => this.CreateWcfCommunicationListener(context), "WCFServiceEndpoint"),
                new ServiceInstanceListener(context => this.CreateWcfHiCommunicationListener(context), "WCFHiServiceEndpoint"),
                new ServiceInstanceListener(context => this.CreateDuplexListener(context), "WCFDuplexEndpoint")
            };
        }

        private ICommunicationListener CreateWcfCommunicationListener(StatelessServiceContext context)
        {
            var listener = new WcfCommunicationListener<IHelloContract>(
                wcfServiceObject: new WcfServiceImplementation(),
                serviceContext: context,
                endpointResourceName: "WCFServiceEndpoint",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
            return listener;
        }

        private ICommunicationListener CreateWcfHiCommunicationListener(StatelessServiceContext context)
        {
            var listener = new WcfCommunicationListener<IHiContract>(
               wcfServiceObject: new HiImplementation(),
               serviceContext: context,
               endpointResourceName: "WCFHiServiceEndpoint",
               listenerBinding: WcfUtility.CreateTcpListenerBinding()
           );
            return listener;
        }

        private ICommunicationListener CreateDuplexListener(StatelessServiceContext context)
        {
            var listener = new WcfCommunicationListener<IDuplexContract>(
                wcfServiceObject: new WcfDuplexImplementation(),
                serviceContext: context,
                endpointResourceName: "WCFDuplexEndpoint",
                listenerBinding: WcfUtility.CreateTcpListenerBinding()
            );
            return listener;
        }
    }
}