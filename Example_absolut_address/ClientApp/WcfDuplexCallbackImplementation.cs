using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class WcfDuplexCallbackImplementation : IDuplexCallback
    {
        public string HelloFromClient()
        {
            return "Hello from Client";
        }
    }
}
