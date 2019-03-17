using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fibonacci.Test
{
    [TestClass]
    public class TestBigInteger2
    {
        [TestMethod]
        public void TestAdd()
        {
            var a = BigInteger2.Add("1".ToCharArray(), "00".ToCharArray());

           Assert.AreEqual((123 + 456).ToString(),  BigInteger2.Add("123".ToCharArray(), "456".ToCharArray()));
           Assert.AreEqual((298 + 726).ToString(),  BigInteger2.Add("298".ToCharArray(), "726".ToCharArray()));
           Assert.AreEqual((1298 + 926).ToString(), BigInteger2.Add("1298".ToCharArray(), "926".ToCharArray()));        
        }

        [TestMethod]
        public void TestSub()
        {
            var a = BigInteger2.Sub("1".ToCharArray(), BigInteger2.RemoveZero("00").ToCharArray());
            Assert.AreEqual((456 - 123).ToString(), BigInteger2.Sub("456".ToCharArray(), "123".ToCharArray()));
            Assert.AreEqual((298 - 726).ToString(), BigInteger2.Sub("298".ToCharArray(), "726".ToCharArray()));
            Assert.AreEqual((1298 - 926).ToString(), BigInteger2.Sub("1298".ToCharArray(), "926".ToCharArray()));
        }

        [TestMethod]
        public void TestParse()
        {
            var a = BigInteger2.ToIntegerString("0".ToCharArray());
        }
    }
}
