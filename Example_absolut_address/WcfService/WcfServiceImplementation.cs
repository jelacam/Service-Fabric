using Microsoft.ServiceFabric.Data.Collections;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    public class WcfServiceImplementation : IHelloContract
    {
        public string AnotherHello()
        {
            return "Another hello message from Stateless service ";
        }

        public string Hello()
        {
            return "Hello form Stateless service ";
        }
    }
}