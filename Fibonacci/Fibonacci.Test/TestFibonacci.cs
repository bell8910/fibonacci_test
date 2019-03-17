using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci.Test
{
    [TestClass]
    public class TestFibonacci
    {
        [TestMethod]
        public void TestLoopAdd()
        {
            var res = Karatsuba.loop_add("123456", "3");
            Assert.AreEqual(res, (123456*3).ToString());

        }

        [TestMethod]
        public void TestPower()
        {
            var res = Karatsuba.loop_add("123456", "3");
            Assert.AreEqual(res, (123456 * 3).ToString());

        }


        [TestMethod]
        public void TestKaratsuba()
        {
            var res = Karatsuba.karatsuba("0", "10");
            Assert.AreEqual(res, "0");
             res = Karatsuba.karatsuba("200", "10");
             Assert.AreEqual(res, "2000");
            var res2 = Karatsuba.karatsuba("1234", "9876");
            Assert.AreEqual(res2, (1234 * 9876).ToString());
            res2 = Karatsuba.karatsuba("123497", "9876");
            Assert.AreEqual(res2, (123497 * 9876).ToString());

        }


        [TestMethod]
        public void TestMatrixPower()
        {
            var x = Fibonacci.FiboMatrix;
            var y = new string[2, 2] { { "1", "0" }, { "0", "1" } };
          //  var z = Fibonacci.Matrix_mul(x, y);
           string value = null;
            /*
           var n2 = Fibonacci.Get_FirstN_By_Matrix_power(2,out value);
            Debug.WriteLine("n={0},value={1}",n2,value);
            Assert.AreEqual(n2,7);
            Assert.AreEqual(value, "13");

            var n3 = Fibonacci.Get_FirstN_By_Matrix_power(3,out value);
            Debug.WriteLine("n={0},value={1}", n3, value);
            Assert.AreEqual(n3,12);
            Assert.AreEqual(value, "144");
            */

           // var start = Fibonacci.Get_LastN_By_Matrix_power(1000);
            // var result = Fibonacci.Check_N_By_BinarySearch(4096);
            var n1000 = Fibonacci.Get_FirstN_By_Matrix_power(1000, out value);
            Debug.WriteLine("n={0},value={1}", n1000, value);
        }




    }
}
