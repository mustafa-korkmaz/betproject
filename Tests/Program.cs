using System;
using System.Threading;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var rivaloTester = new RivaloTester();

            int testIndex = 0;

            while (true)
            {
                Console.WriteLine($"Test {++testIndex} started..");

                rivaloTester.UpdateRivaloEvents();

                rivaloTester.UpdatePlayerBets();

                Thread.Sleep(300000); // wait 5 mins

            }
        }
    }
}
