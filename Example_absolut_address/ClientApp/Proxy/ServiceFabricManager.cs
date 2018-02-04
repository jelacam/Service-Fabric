using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Proxy
{
    public static class ServiceFabricManager
    {
        public static Dictionary<string, ServiceFabricDetails> ServiceFabricMapper = new Dictionary<string, ServiceFabricDetails>()
        {
            ["WcfService"] = new ServiceFabricDetails()
            {
                ServiceFabricUri = new Uri("fabric:/WcfBasedCommunication/WcfService"),
                ContractListenerMapper = new Dictionary<Type, string>()
                {
                    [typeof(IHelloContract)] = "WCFServiceEndpoint",
                    [typeof(IHiContract)] = "WCFHiServiceEndpoint"
                }
            },
            ["WcfStatefulService"] = new ServiceFabricDetails()
            {
                ServiceFabricUri = new Uri("fabric:/WcfBasedCommunication/WcfStatefulService"),
                ContractListenerMapper = new Dictionary<Type, string>()
                {
                    [typeof(IHelloContract)] = "HelloEndpoint",
                    [typeof(IHiContract)] = "HiEndpoint"
                }
            }
        };
    }
}