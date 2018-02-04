using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Proxy
{
    public abstract class ServiceProxyPool<T> where T : class
    {
        private static WcfCommunicationClientFactory<T> factory;
        private static ServicePartitionClient<WcfCommunicationClient<T>> proxy;
        private static object locker = new object();

        public static TResult Invoke<TResult>(Func<WcfCommunicationClient<T>, TResult> method, string serviceName)
        {
            lock (locker)
            {
                factory = new WcfCommunicationClientFactory<T>(clientBinding: WcfUtility.CreateTcpClientBinding(),
                                                               servicePartitionResolver: new ServicePartitionResolver());
                proxy = new ServicePartitionClient<WcfCommunicationClient<T>>(
                        communicationClientFactory: factory,
                        serviceUri: ServiceFabricManager.ServiceFabricMapper[serviceName].ServiceFabricUri,
                        listenerName: ServiceFabricManager.ServiceFabricMapper[serviceName].ContractListenerMapper[typeof(T)]);

                try
                {
                    var result = proxy.InvokeWithRetry(method);
                    return result;
                }
                catch (TimeoutException e)
                {
                    Trace.TraceError("WCF Client Timeout Exception " + e.Message);
                    throw;
                }
                catch (CommunicationException e)
                {
                    Trace.TraceError("WCF Client Communication Exception " + e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    Trace.TraceError("WCF Client Exception " + e.Message);
                    throw;
                }
            }
        }
    }
}