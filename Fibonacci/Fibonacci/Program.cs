using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fibonacci
{
    class Program
    {
        static int[,] FiboMatrix = new int[2, 2] {{1, 1}, {1, 0}};


        //矩阵乘法
        static int[,] Matrix_mul(int[,] x,int[,] y) 
         {  
            int i,j,k;
            var tmp = new int[2, 2] {{0, 0}, {0, 0}};
            for(i=0; i<2; i++)  
                for(j=0; j<2; j++)  
                    for(k=0; k<2; k++)
                        tmp[i,j] += x[i,k] * y[k,j];  
            return tmp;  
        }

        //输出矩阵结果
        static void OutputMatrix(int[,] x)
        {
           for(var i=0;i<2;i++)
           {
               for(var j=0;j<2;j++)
                   Console.Write(x[i,j] + " ");
               Console.WriteLine();
           }
              
        }

        //矩阵快速求幂
        static int[,] Matrix_power(int[,] x, int p)
        {
            var y = new int[2, 2] {{1, 0}, {0, 1}};

            while (p > 0)
            {
                if ((p & 1) != 0)
                    y = Matrix_mul(y,x);
                x = Matrix_mul(x, x);
                p >>= 1;
            }
            return y;
        }

        static void Main(string[] args)
        {
            /* var result =Matrix_power(FiboMatrix,10);
             OutputMatrix(result);

             var bigResult =BigInteger.Add("123", "389");
               Console.WriteLine("big number={0}",bigResult);
              
             */
            var mul = Karatsuba.karatsuba("12323213213", "1232131231231");
            Console.WriteLine(mul);
            Console.ReadKey();


        }

    }
}
