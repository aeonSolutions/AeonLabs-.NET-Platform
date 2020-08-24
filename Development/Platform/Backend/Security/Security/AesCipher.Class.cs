using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AeonLabs.Environment.Core;
using Microsoft.VisualBasic;

namespace AeonLabs.Security
{
    public class AesCipher
    {
        private environmentVarsCore stateCore = new environmentVarsCore();

        public AesCipher(environmentVarsCore _state = default)
        {
            if (_state is object)
            {
                stateCore = _state;
            }
        }

        public string encrypt(string plainText)
        {
            string encryptRet = default;
            // missing convert plainText from local encoding to UTF8

            // Check arguments.
            if (plainText is null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }

            if (stateCore.secretKey is null || stateCore.secretKey.ToString().Length <= 0)
            {
                throw new ArgumentNullException("Invalid Key");
            }

            byte[] encrypted;
            var myAes = Aes.Create();
            string strIv = randomizeIV(16);
            var iv = Encoding.UTF8.GetBytes(strIv); // Guid.NewGuid().ToByteArray()
            myAes.Padding = PaddingMode.PKCS7;
            myAes.BlockSize = 128;
            myAes.FeedbackSize = 128;
            myAes.KeySize = 128;
            myAes.Mode = CipherMode.CBC;
            myAes.IV = iv;
            myAes.Key = Encoding.ASCII.GetBytes(stateCore.secretKey.ToString() );
            using (myAes)
            {
                // Create an encryptor to perform the stream transform.
                var encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            encryptRet = Convert.ToBase64String(iv.Concat(encrypted).ToArray());
            return encryptRet;
        }

        public string decrypt(string strCipherText)
        {

            // Check arguments.
            if (strCipherText is null || strCipherText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }

            if (stateCore.secretKey is null || stateCore.secretKey.ToString().Length <= 0)
            {
                throw new ArgumentNullException("Invalid Key");
            }

            byte[] arrSaltAndCipherText = null;
            try
            {
                arrSaltAndCipherText = Convert.FromBase64String(strCipherText);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.ToString());
            }

            var Algo = Aes.Create();
            Algo.Padding = PaddingMode.PKCS7;
            Algo.BlockSize = 128;
            Algo.FeedbackSize = 128;
            Algo.KeySize = 128;
            Algo.Mode = CipherMode.CBC;
            Algo.IV = arrSaltAndCipherText.Take(16).ToArray();
            Algo.Key = Encoding.ASCII.GetBytes(stateCore.secretKey.ToString());
            using (var Decryptor = Algo.CreateDecryptor())
            {
                using (var MemStream = new MemoryStream(arrSaltAndCipherText.Skip(16).ToArray()))
                {
                    using (var CryptStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {
                        using (var Reader = new StreamReader(CryptStream))
                        {
                            return Reader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string GetMD5Hash(string theInput) // returns a hex string
        {
            using (var hasher = MD5.Create())    // create hash object
            {

                // Convert to byte array and get hash
                var dbytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput));

                // sb to create string from bytes
                var sBuilder = new StringBuilder();

                // convert byte data to hex string
                for (int n = 0, loopTo = dbytes.Length - 1; n <= loopTo; n++)
                    sBuilder.Append(dbytes[n].ToString("X2"));
                return sBuilder.ToString();
            }
        }

        private string Bytes2HexString(byte[] bytes_Input)
        {
            var strTemp = new StringBuilder(bytes_Input.Length * 2);
            foreach (byte b in bytes_Input)
                strTemp.Append(Conversion.Hex(b));
            return strTemp.ToString();
        }

        public string randomizeIV(int len)
        {
            var Letters = new List<int>();
            // add ASCII codes for numbers
            for (int i = 49; i <= 57; i++)
                Letters.Add(i);
            // lowercase letters
            for (int i = 97; i <= 122; i++)
                Letters.Add(i);
            // uppercase letters
            for (int i = 65; i <= 90; i++)
                Letters.Add(i);
            var Rnd = new Random();
            var SB = new StringBuilder();
            int Temp;
            for (int count = 1, loopTo = len; count <= loopTo; count++)
            {
                Temp = Rnd.Next(0, Letters.Count);
                SB.Append((char)Letters[Temp]);
            }

            return SB.ToString();
        }
    }
}