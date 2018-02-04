using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    public class WcfDuplexImplementation : IDuplexContract
    {
        public string HelloFormService()
        {
            IDuplexCallback callback = OperationContext.Current.GetCallbackChannel<IDuplexCallback>();
            string ret = callback.HelloFromClient();
            return "Hello from Duplex Stateless Service + Client response: " + ret;
        }
    }
}