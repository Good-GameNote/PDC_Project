using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotExhibition : MonoBehaviour
{
  
    [SerializeField]
    Image _portrait;
    
    [SerializeField]
    TMPro.TextMeshProUGUI _name;

    [SerializeField]
    TMPro.TextMeshProUGUI _level;
    [SerializeField]
    TMPro.TextMeshProUGUI _surPlus;

    // Start is called before the first frame update
    void Awake()
    {
        ISlotExhibition obj = GetComponent<ISlotExhibition>();   
        SetUI(obj);
    }

    public void SetUI(ISlotExhibition data)
    {
        _portrait.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _level.text = data.GiveLevel().ToString();
        _surPlus.text = data.GiveSurplus().ToString();

    }

}
