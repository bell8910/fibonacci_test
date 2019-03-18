using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fibonacci
{
    public class Md5Helper
    {
		public static string ByteArrayToString(byte[] arrInput)
		{
		    int i;
		    StringBuilder sOutput = new StringBuilder(arrInput.Length);
		    for (i=0;i < arrInput.Length -1; i++) 
		    {
		        sOutput.Append(arrInput[i].ToString("X2"));
		    }
		    return sOutput.ToString();
		}
        private static MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
        
        public static int ComputeHash(string source)
        {
            //Create a byte array from source data
            var tmpSource = ASCIIEncoding.ASCII.GetBytes(source);

            //Compute hash based on source data
            var hashed = hashProvider.ComputeHash(tmpSource);

            return BitConverter.ToInt32(hashed, 0);
        }
    }
}
