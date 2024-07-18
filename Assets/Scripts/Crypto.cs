using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Crypto
{
    private static byte[] Test;
    private const int IVSize = 16;

    public static void Testing(byte[] pkey)
    {
        Test = new byte[32];
        Buffer.BlockCopy(pkey, 0, Test, 0,  pkey.Length);
    }

    public static byte[] Encrypt(byte[] data)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Test;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] iv = new byte[IVSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }

            using (var encryptor = aes.CreateEncryptor(aes.Key, iv))
            using (var ms = new MemoryStream())
            {
                ms.Write(iv, 0, iv.Length);
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }
    }

    public static byte[] Decrypt(byte[] encryptedData)
    {
        if (encryptedData.Length < IVSize)
            throw new ArgumentException("Encrypted data too short");

        using (var aes = Aes.Create())
        {
            aes.Key = Test;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] iv = new byte[IVSize];
            Array.Copy(encryptedData, 0, iv, 0, IVSize);

            using (var decryptor = aes.CreateDecryptor(aes.Key, iv))
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedData, IVSize, encryptedData.Length - IVSize);
                    cs.FlushFinalBlock();
                }
                return ms.ToArray();
            }
        }
    }
}