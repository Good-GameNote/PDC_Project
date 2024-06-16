using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Profile : MonoBehaviour, IObserver<string>
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _nickName;


    public void Set(string data)
    {
        _nickName.text = data;
    }

}
