using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RelicInfo : MonoBehaviour, ISlotMenu
{
    [SerializeField]
    UnityEngine.UI.Image _relicImg;
    [SerializeField]
    UnityEngine.UI.Text _name;
    [SerializeField]
    UnityEngine.UI.Text _explan;
    [SerializeField]
    UnityEngine.UI.Text _surplus;
    [SerializeField]
    UnityEngine.UI.Text _level;

    public void Show(ISlotExhibition purchas)
    {
        _relicImg.sprite = purchas.GiveSprite();
        _name.text = purchas.GiveName();
        //_explan.text = purchas.g
            _surplus.text = purchas.GiveSurplus().ToString();
        _level.text = purchas.GiveLevel().ToString();

        gameObject.SetActive(true);
    }


}
