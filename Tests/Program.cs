using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var rivaloTester=new RivaloTester();

            rivaloTester.StartTesting();

            Console.WriteLine("Test Started..");

            Thread.Sleep(3000); // wait 3 seconds
        }
    }
}
