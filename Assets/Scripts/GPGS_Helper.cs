using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System.Text;
using System;


public class GPGSHelper : MonoBehaviour
{
    public string _tempToken;

    void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();
    }
    void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);       
    }
    internal void ProcessAuthentication(SignInStatus status)
    {
        Debug.Log("@@@@@@@@@@@@@@@@@@@@");
        if(status == SignInStatus.Success)
        {
            CP_Enter cp = new CP_Enter(0);
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(PlayGamesPlatform.Instance.GetUserId()), 0, cp._token, 0, PlayGamesPlatform.Instance.GetUserId().Length);

            Crypto.Testing(Encoding.UTF8.GetBytes("qwerasdfzxcv"));
            byte[] plainText = Encoding.UTF8.GetBytes(PlayGamesPlatform.Instance.GetUserId());
            cp._test = Crypto.Encrypt(plainText);
            GameManager.Instance._packetManager.Send(cp, cp._size);
            Crypto.Testing(cp._token);

        }
        else
        {
#if UNITY_EDITOR              

            Debug.Log("Running in the Unity Editor");
            CP_Enter packet = new CP_Enter(0);
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(_tempToken), 0, packet._token, 0, _tempToken.Length);
            Crypto.Testing(Encoding.UTF8.GetBytes("qwerasdfzxcv"));
            byte[] plainText = Encoding.UTF8.GetBytes(_tempToken);
            packet._test = Crypto.Encrypt(plainText);
            GameManager.Instance._packetManager.Send(packet, packet._size);

            Crypto.Testing(packet._token);

#endif
        }

    }

}