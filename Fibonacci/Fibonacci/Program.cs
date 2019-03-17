using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            string value = null;
            var n1000 = Fibonacci.Get_FirstN_By_Matrix_power(1000, out value);
            Console.WriteLine("n={0}", n1000);
            Console.WriteLine("value={0}", value);
            s.Stop();
            Console.WriteLine("time consume=" + s.Elapsed);
            Console.ReadKey();


        }

    }
}
