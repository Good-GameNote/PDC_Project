
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour, IObserver<sRelic[]>, ISlotExhibition, ISubject<ISlotExhibition>
{
    [field: SerializeField]
    public RelicData _relicData { get; private set; }

    public sRelic[] _sRelic { get; private set; }


    static public Relic CurrentRelic { get; private set; }
    UnityEngine.UI.Button _button;

    private RegistSate State;


    private void Awake()
    {
        sRelic[] _sRelic = new sRelic[1];
        State = GetComponentInParent<RegistSate>();
        _button = gameObject.AddComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(() => { CurrentRelic = this; UI_ClickSlotMenu.Instance.ClickThis(transform, this); });

        GameManager.Instance._inven.ResistObserver((short)_relicData.Index, this);
    }

    public Sprite GiveSprite()
    {
        return _relicData.Sprite;
    }
    public string GiveName()
    {
        return _relicData.Name;
    }

 

    /*
    public string GiveExplan()
    {
        List<string> dumystring= new List<string>();
        for (int i = 0; i < _effectors.Count; i++)
        {
            dumystring.Add(_effectors[i].GiveExplan());
        }
        return CombineStrings(dumystring);
    }
    static string CombineStrings(List<string> words)
    {
        if (words == null || words.Count == 0)
        {
            return string.Empty;
        }

        for (int i = 0; i < words.Count - 1; i++)
        {
            if (i!=words.Count-1 &&words[i].EndsWith("합니다"))
            {
                words[i] = words[i].Substring(0, words[i].Length - 3) + "하고,";
            }
        }

        // 마지막 배열엔 '.'을 추가합니다.
        words[words.Count - 1] += ".";

        // 배열을 하나의 문자열로 합칩니다.
        return string.Join(" ", words);
    }
    */

    public short GiveLevel()
    {
        if (_sRelic==null)
        {
            return 0;
        }
        return _sRelic[0].level;
    }

    public short GiveSurplus()
    {
        if (_sRelic == null)
        {
            return 0;
        }
        return _sRelic[0].surplus;
    }

    List<IObserver<ISlotExhibition>> observers = new();
    public void ResistObserver(IObserver<ISlotExhibition> observer)
    {
        observers.Add(observer);
        if (observers.Count>=1)
        {
            NotifyObservers(this);
        }
    }
    public void NotifyObservers(ISlotExhibition data)
    {
        foreach (IObserver<ISlotExhibition> observer in observers) { observer.Set(data); };
    }

    public void Set(sRelic[] data)
    {
        _sRelic = data;
        
        CurrentRelic = this;
        ChangeState(false);
        NotifyObservers(this);
    }
    public void ChangeState(bool SendPacket)
    {

        bool result = State.Change(ref State,SendPacket);
        if (!SendPacket|| !result)
        {
            return;
        }
        CurrentRelic._sRelic[0]._bitDeckNum ^= (short)(1 << GameManager.Instance._inven.CurDeckNum - 1);

        CP_RegistRelic cp = new CP_RegistRelic(0);
        cp._relicIndex = CurrentRelic._sRelic[0].GiveIndex();
        cp._bitDeckNum = CurrentRelic._sRelic[0]._bitDeckNum;

        GameManager.Instance._packetManager.Send(cp, cp._size);
    }
   

    public short GiveIndex()
    {
        return (short)_relicData.Index;
    }

    public Common.ePage GiveType()
    {
        return Common.ePage.eInven;
    }

  

}
