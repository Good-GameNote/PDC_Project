using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using System.Text;
using System;

public class GPGSHelper : MonoBehaviour
{
    public TextMeshProUGUI logText;

    private void Start()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();


    }
    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);       
    }
    internal void ProcessAuthentication(SignInStatus status)
    {
        if(status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            PlayGamesPlatform.Instance.GetUserId();
            PlayGamesPlatform.Instance.GetUserImageUrl();
            logText.text = "Success \n" + name;
            PlayGamesPlatform.Instance.RequestServerSideAccess(true, (string authCode) =>
            {
                if (!string.IsNullOrEmpty(authCode))
                {
                    Debug.Log("서버 측 액세스 코드 요청 성공: " + authCode);
                    // 이곳에서 authCode를 서버로 전송하여 토큰 교환 및 사용자 인증을 처리
                    CP_Enter packet = new CP_Enter(0);
                    Buffer.BlockCopy(Encoding.UTF8.GetBytes(authCode), 0, packet._token, 0, authCode.Length);

                    GameManager.Instance._packetManager.Send(packet, packet._size);
                }
                else
                {
                    Debug.Log("서버 측 액세스 코드 요청 실패");
                }
            });
        }
        else
        {
            logText.text = "Signin Failed";
        }
        
    }
}