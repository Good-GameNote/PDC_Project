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
    Text _surPlus;
    [SerializeField]
    Button _button;
    short _index;

    private void Awake()
    {

        _button = GetComponent<Button>();
        //_button.onClick.AddListener(() => { UI_Upgrader.Instance.Upgrade(_index); });
        ISubject<ISlotExhibition> _subject= GetComponent<ISubject<ISlotExhibition>>();
        _subject.ResistObserver(this);
        _subject.NotifyObservers();
    }
    public void Set(ISlotExhibition data)
    {
        _portrait.sprite = data.GiveSprite();
        _name.text = data.GiveName();
        _level.text = data.GiveLevel().ToString();
        _surPlus.text = data.GiveSurplus().ToString();
        _index = data.GiveIndex();
    }

}
