using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class EncryptionManager : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaObject keystoreHelper;

    void Start()
    {
        using (AndroidJavaClass keystoreHelperClass = new AndroidJavaClass("com.example.keystore.KeystoreHelper"))
        {
            keystoreHelper = keystoreHelperClass.CallStatic<AndroidJavaObject>("getInstance");
        }
    }

    public byte[] Encrypt(byte[] plainText)
    {
        return keystoreHelper.Call<byte[]>("encrypt", plainText);
    }

    public byte[] Decrypt(byte[] encryptedData)
    {
        return keystoreHelper.Call<byte[]>("decrypt", encryptedData);
    }
#endif
}
