using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Card : MonoBehaviour
{
    protected ICardExhibition _cur2;
    protected UnityEngine.Events.UnityAction<short> _notify;
    [SerializeField]
    Button _button;

    [SerializeField]
    Image _img;
    [SerializeField]
    Text _name;
    [SerializeField]
    Text _value;
    public void SetNotify(UnityEngine.Events.UnityAction<short> notify)
    {
        gameObject.SetActive(true);
        _notify = notify;

    }
    public void SetICardExhibition(ICardExhibition num )
    {
        _cur2 = num;
        _img.sprite = num.GiveSprite();
        _name.text = num.GiveName();
        _value.text = num.GiveExplan(1);//달성도 또는 용병 레벨

    }
    private void Awake()
    {
        _button.onClick.AddListener(CardAction);
    }
    public virtual void CardAction()
    {
        _notify(_cur2.GiveIndex());
    }


}
