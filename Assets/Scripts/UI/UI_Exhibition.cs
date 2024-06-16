using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Exhibition : MonoBehaviour
{
    [SerializeField]
    Image _bg;
    [SerializeField]
    Image _content;
    
    [SerializeField]
    TMPro.TextMeshProUGUI _name;

    [SerializeField]
    TMPro.TextMeshProUGUI _level;

    // Start is called before the first frame update
    void Awake()
    {
        ISlotExhibition obj = GetComponent<ISlotExhibition>();   
        SetUI(obj);
    }

    public void SetUI(ISlotExhibition data)
    {
        _content.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _level.text = data.GiveLevel().ToString();
    }

}
