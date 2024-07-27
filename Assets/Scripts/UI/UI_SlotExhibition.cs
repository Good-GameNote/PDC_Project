using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotExhibition : MonoBehaviour, IObserver<ISlotExhibition>
{
  
    [SerializeField]
    Image _portrait;
    
    [SerializeField]
    Text _name;

    [SerializeField]
    Text _level;

    [SerializeField]
    Image _gage;
    [SerializeField]
    Text _surPlus;


    private void Awake()
    {
        ISubject<ISlotExhibition> _subject= GetComponent<ISubject<ISlotExhibition>>();
        _subject.ResistObserver(this);
    }
    public void Set(ISlotExhibition data)
    {
        if(data == null) { return; }
        _portrait.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _level.text = data.GiveLevel().ToString();
        _surPlus.text = data.GiveSurplus().ToString();
    }

}
