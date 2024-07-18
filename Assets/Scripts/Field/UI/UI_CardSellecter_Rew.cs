using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardSellecter_Rew : UI_CardSellecter
{
    [SerializeField]
    GameObject[] backs;

    [SerializeField]
    GameObject[] check;
    bool isFirst=true;
    public override void Action(short idx)//인덱스 번호 
    {
        if(isFirst)
        {
            check[0].transform.SetParent(_cards[idx].transform);
            check[0].SetActive(true);
            for (int i =0; i < 3; i++)
            {
                _cards[idx%3].SetICardExhibition(_list[i]);
                idx++;
                backs[i].SetActive(false);
            }
            isFirst = false;
        }else
        {
            check[1].transform.SetParent(_cards[idx].transform);
            check[1].SetActive(true);
            Debug.Log("암호 패킷");
        }


        
    }



}
