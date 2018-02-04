using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    [ServiceContract]
    public interface IHelloContract
    {
        [OperationContract]
        string Hello();

        [OperationContract]
        string AnotherHello();
    }
}