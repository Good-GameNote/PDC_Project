using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_CardSellecter : MonoBehaviour
{
    [SerializeField]
    protected UI_Card[] _cards;

    protected ICardExhibition[] _list;//섞어야할때쓸것

    public void SetCard(ICardExhibition[] list = null)
    {
        if(list == null) { gameObject.SetActive(false); return; }
        gameObject.SetActive(true);
        _list = list;
        for(int i =0;i <_cards.Length; i++)
        {
            _cards[i].gameObject.SetActive(false);
            if (i >= list.Length) break;
            _cards[i].SetICardExhibition( list[i]);
            _cards[i].SetNotify(Action);
        }
    }
    //  UI_MercenaryAction.Instance.Choice(Effector.Effectors[idx]);
    
    public abstract void Action(short idx);

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}

