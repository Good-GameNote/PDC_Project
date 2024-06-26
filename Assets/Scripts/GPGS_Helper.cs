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
        if(status == SignInStatus.Success)
        {
            string name = PlayGamesPlatform.Instance.GetUserDisplayName();
            PlayGamesPlatform.Instance.GetUserId();
            PlayGamesPlatform.Instance.GetUserImageUrl();
            PlayGamesPlatform.Instance.RequestServerSideAccess(true, (string authCode) =>
            {
                if (!string.IsNullOrEmpty(authCode))
                {
                    Debug.Log("서버 측 액세스 코드 요청 성공: " + authCode);
                    // 이곳에서 authCode를 서버로 전송하여 토큰 교환 및 사용자 인증을 처리
                    CP_Enter cp = new CP_Enter(0);
                    Buffer.BlockCopy(Encoding.UTF8.GetBytes(authCode), 0, cp._token, 0, authCode.Length);
                    GameManager.Instance._packetManager.Send(cp, cp._size);
                }
                else
                {
                    Debug.Log("서버 측 액세스 코드 요청 실패");
                }
            });
        }
        else
        {
            Debug.Log("Running in the Unity Editor");
            CP_Enter packet = new CP_Enter(0);
            Buffer.BlockCopy(Encoding.UTF8.GetBytes(_tempToken), 0, packet._token, 0, _tempToken.Length);
            GameManager.Instance._packetManager.Send(packet, packet._size);
        }
        
    }
#if UNITY_EDITOR

#elif UNITY_ANDROID

#endif
}