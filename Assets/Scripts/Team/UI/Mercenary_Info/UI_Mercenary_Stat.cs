using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mercenary_Stat : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image _icon;
    [SerializeField]
    UnityEngine.UI.Text _value;

    public void SetData(Sprite icon, string value)
    {
        _icon.sprite = icon;
        _value.text = value;
        gameObject.SetActive(true);
    }
    public bool IsMatch(Sprite icon)
    {
        return _icon.sprite == icon;
    }

 

}
