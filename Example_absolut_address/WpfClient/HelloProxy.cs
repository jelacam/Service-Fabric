using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WpfClient
{
    public class HelloProxy : IHelloContract
    {
        private static ServicePartitionResolver resolver = new ServicePartitionResolver();

        private static ChannelFactory<IHelloContract> factory;
        private static IHelloContract proxy;

        public static IHelloContract Instance
        {
            get
            {
                if (proxy == null)
                {
                    factory = new ChannelFactory<IHelloContract>();

                    proxy = factory.CreateChannel();
                }
                return proxy;
            }
            set
            {
                if (proxy == null)
                {
                    proxy = value;
                }
            }
            //factory = new WcfCommunicationClientFactory<IHelloContract>(
            //            clientBinding: WcfUtility.CreateTcpClientBinding(),
            //            servicePartitionResolver: resolver,
            //            traceId: "HelloProxy_Stateless");

            //proxy = new ServicePartitionClient<WcfCommunicationClient<IHelloContract>>(
            //        communicationClientFactory: factory,
            //        serviceUri: new Uri("fabric:/WcfBasedCommunication/WcfService"),
            //        listenerName: "WCFServiceEndpoint");
        }

        public string AnotherHello()
        {
            return proxy.AnotherHello();
        }

        public string Hello()
        {
            return proxy.Hello();
        }
    }
}