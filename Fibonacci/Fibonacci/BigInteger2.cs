using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    public class BigInteger2
    {
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>返回结果</returns>
        public static string Add(char[] num1, char[] num2)
        {
            //对两个加数进行初始化，使长度相同
            if (num1.Length > num2.Length)
                num2 = InitString(num1, num2);
            if (num1.Length < num2.Length)
                num1 = InitString(num1, num2);
            string result = "";
            string finalRes = "";
            //每一位相加都保留进位
            int jinwei = 0;
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                //将字符转换为数字
                int res = num1[i] + num2[i] - 2 * '0' + jinwei;
                jinwei = 0;
                if (res >= 10)
                {
                    jinwei = 1;
                    res -= 10;
                }
                result += res;
            }
            if (jinwei > 0)
                result += jinwei;
            //将结果反转
            for (int i = result.Length - 1; i >= 0; i--)
            {
                finalRes += result[i];
            }
            //移除不必要的零
            finalRes = RemoveZero(finalRes);
            return finalRes;
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>返回结果</returns>
        public static string Sub(char[] num1, char[] num2)
        {
            string result = "";
            string finalRes = "";
            //保留两个数相减的借位，用于下一位计算
            int jiewei = 0;
            //判断两个数的大小，决定是否加“-”号
            int bigger = num1BiggerThanNum2(num1, num2);
            if (bigger < 0)
            {
                char[] c = num1;
                num1 = num2;
                num2 = c;
                finalRes += '-';
            }
            if (bigger == 0)
                return "0";
            //将两个数初始化，使位数相同
            if (num1.Length > num2.Length)
                num2 = InitString(num1, num2);
            if (num1.Length < num2.Length)
                num1 = InitString(num1, num2);
            for (int i = num1.Length - 1; i >= 0; i--)
            {
                //两数相减，不需要将字符转换为数字
                int res = num1[i] - num2[i] - jiewei;
                jiewei = 0;
                if (res < 0)
                {
                    res += 10;
                    jiewei = 1;
                }
                result += res;
            }
            //将结果反转
            for (int i = result.Length - 1; i >= 0; i--)
            {
                finalRes += result[i];
            }
            finalRes = RemoveZero(finalRes);
            return finalRes;
        }
        


        /// <summary>
        /// 将两个字符串进行初始化，以达到相同的长度，在较短的字符串前边补零
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>返回初始化后的字符串</returns>
        public static char[] InitString(char[] a, char[] b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            char[] c = new char[Math.Max(aLength, bLength)];
            int start = Math.Abs(aLength - bLength);
            for (int i = 0; i < Math.Max(aLength, bLength); i++)
            {
                if (i < start)
                    c[i] = '0';
                else
                {
                    if (aLength > bLength)
                        c[i] = b[i - start];
                    if (aLength < bLength)
                        c[i] = a[i - start];
                }
            }
            return c;
        }

        /// <summary>
        /// 判断两个数的大小
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>num1大于num2，则返回1；num1等于num2，则返回0；num1小于num2，则返回-1；</returns>
        public static int num1BiggerThanNum2(char[] num1, char[] num2)
        {
            if (num1.Length > num2.Length)
            {
                return 1;
            }
            if (num1.Length < num2.Length)
            {
                return -1;
            }
            if (num1.Length == num2.Length)
            {
                for (int i = 0; i < num2.Length; i++)
                {
                    if (num1[i] > num2[i])
                        return 1;
                    else if (num1[i] < num2[i])
                        return -1;
                }
            }
            return 0;
        }

        public static string ToIntegerString(char[] input)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                output += input[i] - '0'; // Subtract '0' here.
            }
            return output;
        }
        /// <summary>
        /// 移除字符串前边不必要的零
        /// </summary>
        /// <param name="str"></param>
        /// <returns>返回正确字符串</returns>
        public static string RemoveZero(string str)
        {
            string result = "";
            bool start = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '0')
                {
                    start = true;
                }
                if (start)
                    result += str[i];
            }
            return result;
        }
    }
}


