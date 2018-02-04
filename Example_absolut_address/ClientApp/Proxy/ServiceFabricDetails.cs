using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Proxy
{
    public class ServiceFabricDetails
    {
        private Uri serviceFabricUri;
        private Dictionary<Type, string> contractListenerMapper;

        public Uri ServiceFabricUri
        {
            get
            {
                return serviceFabricUri;
            }
            set
            {
                serviceFabricUri = value;
            }
        }

        public Dictionary<Type, string> ContractListenerMapper
        {
            get
            {
                return contractListenerMapper;
            }
            set
            {
                contractListenerMapper = value;
            }
        }
    }
}