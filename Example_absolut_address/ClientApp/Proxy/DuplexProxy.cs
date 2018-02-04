using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Proxy
{
    public class DuplexProxy : IDuplexContract
    {
        private ServicePartitionResolver resolver = new ServicePartitionResolver();

        private WcfCommunicationClientFactory<IDuplexContract> factory;
        private ServicePartitionClient<WcfCommunicationClient<IDuplexContract>> proxy;

        public DuplexProxy(string serviceUri)
        {
            factory = new WcfCommunicationClientFactory<IDuplexContract>(clientBinding: WcfUtility.CreateTcpClientBinding(),
                                                                         servicePartitionResolver: resolver,
                                                                         callback: new WcfDuplexCallbackImplementation());
            proxy = new ServicePartitionClient<WcfCommunicationClient<IDuplexContract>>(
                    communicationClientFactory: factory,
                    serviceUri: new Uri(serviceUri),
                    listenerName: "WCFDuplexEndpoint");
        }

        public string HelloFormService()
        {
            return proxy.InvokeWithRetry(client => client.Channel.HelloFormService());
        }
    }
}