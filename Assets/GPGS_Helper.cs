using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

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
        }
        else
        {
            logText.text = "Signin Failed";
        }
        
    }
}