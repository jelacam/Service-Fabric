using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    public class HiImplementation : IHiContract
    {
        public string Hi()
        {
            return "Hi from Stateless service";
        }
    }
}
