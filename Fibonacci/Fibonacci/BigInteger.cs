using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    public class BigInteger
    {
         
      /*

        public static string Add(string str1, string str2)
        {
            //记录最终结果
            string rst = "";
            //i和j用于位数对齐
            int i = str1.Length - 1, j = str2.Length - 1, carry = 0;
            int tempI = 0, tempJ = 0, tempR = 0;
            while (i >= 0 || j >= 0)
            {
                //采集数字。长度不够的，高位用0补
                if (i >= 0)
                    tempI = str1[i--] - '0';
                else
                    tempI = 0;

                if (j >= 0)
                    tempJ = str2[j--] - '0';
                else
                    tempJ = 0;
                //加法
                tempR = tempI + tempJ + carry;
                carry = tempR > 9 ? 1 : 0;
                tempR %= 10;
                tempR += '0';
                //本位留存到结果
                rst = (char) tempR + rst;
            }
            //最高位的向前进位
            if (carry == 1)
                rst = '1' + rst;
            return rst;
        }
       * */
    }
}
