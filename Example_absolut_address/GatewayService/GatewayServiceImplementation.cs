using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatewayService
{
    public class GatewayServiceImplementation : IHelloContract
    {
        public string AnotherHello()
        {
            throw new NotImplementedException();
        }

        public string Hello()
        {
            HelloProxy proxy = new HelloProxy();
            return proxy.Hello();
        }
    }
}
