using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mercenary_Top : MonoBehaviour
{

    [SerializeField]
    UnityEngine.UI.Image _img;

    [SerializeField]
    UnityEngine.UI.Text _name;

    [SerializeField]
    UnityEngine.UI.Text _level;

    public void SetTop(ISlotExhibition data)
    {
        _img.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _level.text=  $"Lv. {data.GiveLevel()}";
    }
}
