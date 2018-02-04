using Microsoft.ServiceFabric.Services.Remoting.Client;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfStatefulService
{
    public class Hi : IHiContract
    {
        string IHiContract.Hi()
        {
            HelloProxy helloProxy = new HelloProxy("fabric:/WcfBasedCommunication/WcfService");
            var res = helloProxy.AnotherHello();

            return "Hi " + res.ToString();
        }
    }
}