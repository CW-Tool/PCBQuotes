using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PCBQuotes.Helpers
{
    public class EncryptDecryptHelper
    {
        #region aes
        private static string AesKey = "12345678901234567890123456789012";
        /// <summary>
        /// aes 加密
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string AesEncrypt(string toEncrypt)
        {
            var keyArray = Encoding.UTF8.GetBytes(AesKey); ;
            var toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);
            using (var acsp = new AesCryptoServiceProvider { KeySize = 128, BlockSize = 128 })
            {
                acsp.GenerateIV();
                using (var aes = new AesCryptoServiceProvider { Key = keyArray, IV = acsp.IV, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    byte[] resultArray;
                    using (var cTransform = aes.CreateEncryptor())
                    {
                        resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    }
                    return Convert.ToBase64String(resultArray);
                }
            }
        }
        /// <summary>
        /// aes解密
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string AesDecrypt(string toDecrypt)
        {
            var keyArray = Encoding.UTF8.GetBytes(AesKey);
            var toDecryptArray = Convert.FromBase64String(toDecrypt);
            using (var acsp = new AesCryptoServiceProvider { KeySize = 128, BlockSize = 128 })
            {
                acsp.GenerateIV();
                using (var aes = new AesCryptoServiceProvider { Key = keyArray, IV = acsp.IV, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    byte[] resultArray;
                    using (var cTransform = aes.CreateDecryptor())
                    {
                        resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length);
                    }
                    return Encoding.UTF8.GetString(resultArray);
                }
            }
        }
        #endregion

        #region des
        private static string DesKey = "23456789";//必须8位
        private static string DesIV = "dsc365.c";//必须8位
        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="dataToEncrypt"></param>
        /// <returns></returns>
        public static string DESEncrypt(string dataToEncrypt)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.Default.GetBytes(dataToEncrypt);//把字符串放到byte数组中
                des.Key = ASCIIEncoding.ASCII.GetBytes(DesKey); //建立加密对象的密钥和偏移量
                des.IV = ASCIIEncoding.ASCII.GetBytes(DesIV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        StringBuilder ret = new StringBuilder();
                        foreach (byte b in ms.ToArray())
                        {
                            ret.AppendFormat("{0:x2}", b);
                        }
                        return ret.ToString();
                    }
                }
            }
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="dataToDecrypt"></param>
        /// <returns></returns>
        public static string DESDecrypt(string dataToDecrypt)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = new byte[dataToDecrypt.Length / 2];
                for (int x = 0; x < dataToDecrypt.Length / 2; x++)
                {
                    int i = (Convert.ToInt32(dataToDecrypt.Substring(x * 2, 2), 16));
                    inputByteArray[x] = (byte)i;
                }
                des.Key = ASCIIEncoding.ASCII.GetBytes(DesKey); //建立加密对象的密钥和偏移量，此值重要，不能修改
                des.IV = ASCIIEncoding.ASCII.GetBytes(DesIV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        return System.Text.Encoding.Default.GetString(ms.ToArray());
                    }
                }
            }
        }
        #endregion
        public static string MakePassword(string pwdchars, int pwdlen)
        {
            if (string.IsNullOrWhiteSpace(pwdchars))
            {
                pwdchars = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            string tmpstr = "";
            int iRandNum;
            Random rnd = new Random();
            for (int i = 0; i < pwdlen; i++)
            {
                iRandNum = rnd.Next(pwdchars.Length);
                tmpstr += pwdchars[iRandNum];
            }
            return tmpstr;
        }

        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("X2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

        public static string GetStringMD5(string text)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
