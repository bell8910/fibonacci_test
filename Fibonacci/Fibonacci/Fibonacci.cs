using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fibonacci
{
    public class Fibonacci
    {
        public static string[,] FiboMatrix = new string[2, 2] { { "1", "1" }, { "1", "0" } };

        class MatrixValue
        {
            public string x;
            public string[,] sqrValue;
        }
        private const int minLengthForCache = 20;
        private static Dictionary<int, List<MatrixValue>> _matrixCache = new Dictionary<int, List<MatrixValue>>();

        public static string[,] GetFromCache(int hash,string xValue)
        {
            
            if (_matrixCache.ContainsKey(hash))
            {
                var mVal = _matrixCache[hash].FirstOrDefault(m => m.x == xValue);
                if (mVal != null)
                {
                    return mVal.sqrValue;
                }
            }

            return null;
        }

        public static void SetValueToCache(int hash,string xValue,string[,] sqrValue)
        {
            List<MatrixValue> mValList = null;
            if (_matrixCache.ContainsKey(hash))
                mValList = _matrixCache[hash];
            else
            {
                mValList = new List<MatrixValue> {};
                _matrixCache.Add(hash,mValList);
            }
            mValList.Add(new MatrixValue
                {
                    x = xValue,
                    sqrValue = sqrValue
                });
            
        }

        //矩阵乘法
        public static string[,] Matrix_mul(string[,] x, string[,] y)
        {
            var needSaveToCache = false;
            int hash=0;
            var value = x[0, 1];
            if (x[0, 1].Length > minLengthForCache && x[0, 1] == y[0, 1])
            {
                hash = Md5Helper.ComputeHash(value);
                var res = GetFromCache(hash,value);
                if (res != null)
                    return res;
                needSaveToCache = true;
            }

            int i, j, k;
            var tmp = new string[2, 2] { { "0", "0" }, { "0", "0" } };
            for (i = 0; i < 2; i++)
                for (j = 0; j < 2; j++)
                    for (k = 0; k < 2; k++)
                    {
                        var xy = Karatsuba.karatsuba(x[i, k], y[k, j]);
                        tmp[i,j] = BigInteger2.Add(tmp[i, j].ToCharArray(),xy.ToCharArray());
                    }


            if (needSaveToCache)
                SetValueToCache(hash, value, tmp);

            return tmp;
        }

        //输出矩阵结果
        static void OutputMatrix(string[,] x)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                    Debug.Write(x[i, j] + string.Format("({0}),",x[i,j].Length));
                Debug.WriteLine("");
            }

        }

        

        // 矩阵快速求幂判断是否大于长度length
        // true 表示 >= length
        public static bool Check_N_By_BinarySearch(int p ,int length,out string value)
        {
            var x = FiboMatrix;
            var y = new string[,] { { "1", "0" }, { "0", "1" } };
            value = null;
             while (p > 0)
             {
                 if ((p & 1) > 0)
                 {
                     y = Matrix_mul(y, x);
                     if (y[0, 1].Length >= length)
                     {
                          value = y[0, 1];
                         //Debug.WriteLine("value={0}",value);
                         return true;
                     }
                 }

                x = Matrix_mul(x, x);
                //OutputMatrix(y);
                p >>= 1;
                
            }

            return false;
        }

        //折半查找
        public static int Get_N_By_BinarySearch(int start, int end, int length,ref string value)
        {
             Debug.WriteLine("start={0},end={1}", start, end);
             Console.WriteLine("start={0},end={1}",start,end);
            if (end - start <= 1)
            {
                if (value == null)
                    Check_N_By_BinarySearch(end, length, out value);
                return end;
            }
            var startLogVal = Math.Log(start, 2);
            var endLogVal = Math.Log(end, 2);
            var middle =  (int)Math.Floor(Math.Pow(2,(endLogVal - startLogVal)/2 + startLogVal));
            if (middle <= start)
                middle = start + 1;
          
           // //Math.Floor((double) (end - start)/2) + start;
            string checkValue = null;
            if (Check_N_By_BinarySearch(middle, length,out checkValue))
            {
                value = checkValue;
                return Get_N_By_BinarySearch(start, middle, length,ref value);
            }
            else
            {
                return Get_N_By_BinarySearch(middle, end, length,ref value);
            }
        }

        //矩阵快速求幂
        public static int Get_FirstN_By_Matrix_power(int length,out string value)
        {
           
            Console.WriteLine("start compute the n by length of {0}",length);
            var range = Get_Range_By_Matrix_power(length);
            Console.WriteLine("Get range start={0},end={1} ",range.Item1,range.Item2);
           
            string refValue = null;
            var n = Get_N_By_BinarySearch(range.Item1,range.Item2,length,ref refValue);
            value = refValue;
            return n;
        }

        //找到长度小于length的n值
        public static Tuple<int,int> Get_Range_By_Matrix_power(int length)
        {
            var x = FiboMatrix;
            var y = new string[,]{{"1","0"},{"0","1"}};

            var p = 1;
            var lastP = 0;
            while (true)
            {
                if (y[0, 1].Length >= length)
                    return new Tuple<int, int>(lastP >> 1, lastP);
                
                y = Matrix_mul(y, x);
                x = Matrix_mul(x, x);
                //OutputMatrix(y);
                //Debug.WriteLine("p={0},lastP={1}", p,lastP);
                lastP = p;
                p = (p<<1) + 1;
            }
        }

      
    }
}
