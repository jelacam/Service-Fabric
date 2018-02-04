using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Proxy
{
    public class HiProxy : IHiContract
    {
        private static IServicePartitionResolver resolver = new ServicePartitionResolver();

        private static WcfCommunicationClientFactory<IHiContract> factory;
        private static ServicePartitionClient<WcfCommunicationClient<IHiContract>> proxy;

        public static ServicePartitionClient<WcfCommunicationClient<IHiContract>> Instance
        {
            get
            {
                factory = new WcfCommunicationClientFactory<IHiContract>(clientBinding: WcfUtility.CreateTcpClientBinding(), servicePartitionResolver: resolver);
                proxy = new ServicePartitionClient<WcfCommunicationClient<IHiContract>>(
                    communicationClientFactory: factory,
                    serviceUri: new Uri("fabric:/WcfBasedCommunication/WcfStatefulService"),
                    listenerName: "HiEndpoint",
                    partitionKey: new ServicePartitionKey(1));
                return proxy;
            }

            set
            {
                proxy = value;
            }
        }

        public string Hi()
        {
            return proxy.InvokeWithRetry(client => client.Channel.Hi());
        }
    }
}