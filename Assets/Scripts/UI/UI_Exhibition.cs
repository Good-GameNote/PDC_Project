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
    TMPro.TextMeshProUGUI _explane;

    // Start is called before the first frame update
    void Awake()
    {
        ICanExhibition obj = GetComponent<ICanExhibition>();   
        SetUI(obj);
    }

    void SetUI(ICanExhibition data)
    {
        _content.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _explane.text = data.GiveExplan(data.GiveValue());
    }

}
