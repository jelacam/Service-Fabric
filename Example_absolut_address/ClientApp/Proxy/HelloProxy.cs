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

namespace ClientApp.Proxy
{
    public class HelloProxy : IHelloContract
    {
        private static ServicePartitionResolver resolver = new ServicePartitionResolver();

        private static WcfCommunicationClientFactory<IHelloContract> factory;
        private static ServicePartitionClient<WcfCommunicationClient<IHelloContract>> proxy;

        public static ServicePartitionClient<WcfCommunicationClient<IHelloContract>> Instance
        {
            get
            {
                factory = new WcfCommunicationClientFactory<IHelloContract>(clientBinding: WcfUtility.CreateTcpClientBinding(), servicePartitionResolver: resolver);
                proxy = new ServicePartitionClient<WcfCommunicationClient<IHelloContract>>(
                        communicationClientFactory: factory,
                        serviceUri: new Uri("fabric:/WcfBasedCommunication/WcfService"),
                        listenerName: "WCFServiceEndpoint");

                return proxy;
            }

            set
            {
                proxy = value;
            }
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