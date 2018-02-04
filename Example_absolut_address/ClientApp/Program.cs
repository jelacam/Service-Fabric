using ClientApp.Proxy;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Communication.Client;
using Microsoft.ServiceFabric.Services.Communication.Wcf;
using Microsoft.ServiceFabric.Services.Communication.Wcf.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //HelloProxy statelessServiceHelloProxy = new HelloProxy("fabric:/WcfBasedCommunication/WcfService");
            //var res = statelessServiceHelloProxy.Hello();
            //Console.WriteLine(res.ToString());

            //HiProxy statelessServiceHiProxy = new HiProxy("fabric:/WcfBasedCommunication/WcfService");
            //var res2 = statelessServiceHiProxy.Hi();
            //Console.WriteLine(res2.ToString());

            //HelloProxy statefulServiceHelloProxy = new HelloProxy("fabric:/WcfBasedCommunication/WcfService");
            //var res3 = statefulServiceHelloProxy.Hello();
            //var res4 = statefulServiceHelloProxy.AnotherHello();

            //HiProxy statefulServiceHiProxy = new HiProxy("fabric:/WcfBasedCommunication/WcfStatefulService");
            //var resHi = statefulServiceHiProxy.Hi();
            //Console.WriteLine(resHi.ToString());

            string response = ServiceProxyPool<IHelloContract>.Invoke(x => x.Channel.Hello(), "WcfService");
            Console.WriteLine(response.ToString());

            string response3 = ServiceProxyPool<IHelloContract>.Invoke(x => x.Channel.Hello(), "WcfService");
            Console.WriteLine(response3.ToString());

            string response4 = ServiceProxyPool<IHelloContract>.Invoke(x => x.Channel.Hello(), "WcfService");
            Console.WriteLine(response4.ToString());

            string response5 = ServiceProxyPool<IHelloContract>.Invoke(x => x.Channel.Hello(), "WcfService");
            Console.WriteLine(response5.ToString());

            string response6 = ServiceProxyPool<IHelloContract>.Invoke(x => x.Channel.Hello(), "WcfService");
            Console.WriteLine(response6.ToString());

            string response7 = HelloProxy.Instance.InvokeWithRetry(client => client.Channel.Hello());
            Console.WriteLine(response7.ToString());

            string response8 = HelloProxy.Instance.InvokeWithRetry(client => client.Channel.Hello());
            Console.WriteLine(response8.ToString());

            string response9 = HelloProxy.Instance.InvokeWithRetry(client => client.Channel.Hello());
            Console.WriteLine(response9.ToString());

            string response10 = HelloProxy.Instance.InvokeWithRetry(client => client.Channel.Hello());
            Console.WriteLine(response10.ToString());

            string response11 = HelloProxy.Instance.InvokeWithRetry(client => client.Channel.Hello());
            Console.WriteLine(response11.ToString());

            string response_stateful1 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful1.ToString());

            string response_stateful2 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful2.ToString());

            string response_stateful3 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful3.ToString());

            string response_stateful4 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful4.ToString());

            string response_stateful5 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful5.ToString());

            string response_stateful6 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful6.ToString());

            string response_stateful7 = HiProxy.Instance.InvokeWithRetry(x => x.Channel.Hi());
            Console.WriteLine(response_stateful7.ToString());

            //string response2 = ServiceProxyPool<IHiContract>.Invoke(x => x.Channel.Hi(), "WcfService");
            //Console.WriteLine(response2.ToString());

            DuplexProxy proxy = new DuplexProxy("fabric:/WcfBasedCommunication/WcfService");
            string duplexResponse = proxy.HelloFormService();
            Console.WriteLine(duplexResponse);

            Console.ReadKey();
        }
    }
}