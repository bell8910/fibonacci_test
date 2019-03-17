using System;
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


    }
}
