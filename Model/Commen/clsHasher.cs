using System;
using System.Text;
using System.Security.Cryptography;

namespace webSVNUnlocker.Model.Commen
{
    public class clsHasher
    {
        public String getSHA1Hash(String strInput)
        {
            SHA1 SHA1Hasher = SHA1.Create();

            byte[] Data = SHA1Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

            StringBuilder objStringBuilder = new StringBuilder();

            for (int intCounter = 0; intCounter < Data.Length; intCounter++)
            {
                objStringBuilder.Append(Data[intCounter].ToString("x2"));
            }

            return objStringBuilder.ToString().ToUpper();
        }

        public String getSHA254Hash(String strInput)
        {
            SHA256 SHA256Hasher = SHA256.Create();

            byte[] Data = SHA256Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

            StringBuilder objStringBuilder = new StringBuilder();

            for (int intCounter = 0; intCounter < Data.Length; intCounter++)
            {
                objStringBuilder.Append(Data[intCounter].ToString("x2"));
            }

            return objStringBuilder.ToString().ToUpper();
        }

        public String getMD5Hash(String strInput)
        {
            MD5 MD5Hasher = MD5.Create();

            byte[] Data = MD5Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

            StringBuilder objStringBuilder = new StringBuilder();

            for (int intCounter = 0; intCounter < Data.Length; intCounter++)
            {
                objStringBuilder.Append(Data[intCounter].ToString("x2"));
            }

            return objStringBuilder.ToString().ToUpper();
        }
    }
}