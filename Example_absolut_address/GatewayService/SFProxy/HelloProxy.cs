using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using System.ServiceModel;
using System.Fabric;

namespace GatewayService
{
    public class HelloProxy : IHelloContract
    {
        private  ServicePartitionResolver resolver = new ServicePartitionResolver();

        private  WcfCommunicationClientFactory<IHelloContract> factory;
        private  ServicePartitionClient<WcfCommunicationClient<IHelloContract>> proxy;

        public HelloProxy()
        {
           
            factory = new WcfCommunicationClientFactory<IHelloContract>(clientBinding: WcfUtility.CreateTcpClientBinding(), servicePartitionResolver: resolver);
            proxy = new ServicePartitionClient<WcfCommunicationClient<IHelloContract>>(
                    communicationClientFactory: factory,
                    serviceUri: new Uri("fabric:/WcfBasedCommunication/WcfService"),
                    listenerName: "WCFServiceEndpoint");

        }

        public string AnotherHello()
        {
            return proxy.InvokeWithRetry(client => client.Channel.AnotherHello());
        }

        public string Hello()
        {
            return proxy.InvokeWithRetry(client => client.Channel.Hello());
        }
    }
}