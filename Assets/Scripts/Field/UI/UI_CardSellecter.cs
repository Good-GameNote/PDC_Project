using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardSellecter : MonoBehaviour
{
    [SerializeField]
    UI_Card[] _cards;

    Common.eEffector[] _list;
    public void SetCard( Common.eEffector[] list)
    {

        gameObject.SetActive(true);
        _list = list;
        for(int i =0;i <_cards.Length; i++)
        {
            _cards[i].gameObject.SetActive(false);
            if (i >= list.Length) break;
            _cards[i].SetNum(list[i]);
        }

    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

}
