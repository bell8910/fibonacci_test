using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    public class Karatsuba
    {
        struct split_str
        {
            public string high;
            public string low;
        }

        static split_str split_at(string num, int count)
        {
            return new split_str
            {
                high = num.Substring(0, num.Length - count),
                low = BigInteger2.RemoveZero(num.Substring(num.Length - count))
            };
        }

        static string karatsuba_10_pow(string x, int n)
        {
            if (x == "" || x == "0")
                return "0";
            return x + BigInteger2.ToIntegerString(Enumerable.Repeat('0',n).ToArray());
        }


        public static string loop_add(string num1, string num2)
        {
              if (num1.Length == 0 ||num2.Length == 0)
                   return "0";

               string biggerNum = null;
               int count = 0;
               if (num1.Length > num2.Length)
               {
                   biggerNum = num1;
                   count = int.Parse(num2);
               }
               else
               {
                   biggerNum = num2;
                   count = int.Parse(num1);
               }
               
               string sum = "0";
               while (count > 0)
               {
                   sum = BigInteger2.Add(sum.ToCharArray(), biggerNum.ToCharArray());
                   count --;
               }
               return sum;
       }

       public  static  string karatsuba(string num1,string num2)
       {
           if (num1.Length < 2 || num2.Length < 2)
           {
               return loop_add(num1, num2);
           }
           /* calculates the size of the numbers */
            var m = num1.Length < num2.Length ? num1.Length : num2.Length;
            var m2 = (int)Math.Floor((double)m/2); 
           /*m2 = ceil(m/2) will also work */
            
            /* split the digit sequences in the middle */
            var split1 = split_at(num1, m2);
            var split2 = split_at(num2, m2);


          /* 3 calls made to numbers approximately half the size */
            var z0 = karatsuba(split1.low, split2.low);
            var z1 = karatsuba(BigInteger2.Add(split1.low.ToCharArray(),split1.high.ToCharArray()), BigInteger2.Add(split2.low.ToCharArray() ,split2.high.ToCharArray()));
            var z2 = karatsuba(split1.high, split2.high);


           string s1 = karatsuba_10_pow(z2, m2*2);

           var s2_1 = BigInteger2.Sub(z1.ToCharArray(), z2.ToCharArray());
           var s2_2 = BigInteger2.Sub(s2_1.ToCharArray(), z0.ToCharArray());
           var s2 = karatsuba_10_pow(s2_2, m2);

           var s1_2 = BigInteger2.Add(s1.ToCharArray(), s2.ToCharArray());
           return BigInteger2.Add(s1_2.ToCharArray(),z0.ToCharArray());
        }
    }
}
