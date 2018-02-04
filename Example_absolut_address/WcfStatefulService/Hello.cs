using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfStatefulService
{
    public class Hello : IHelloContract
    {
        private int numberOfHellos = 0;

        public string AnotherHello()
        {
            return "Another hello";
        }

        string IHelloContract.Hello()
        {
            numberOfHellos++;
            return "Hello- Number of hellos " + numberOfHellos.ToString();
        }
    }
}