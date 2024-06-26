
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic: MonoBehaviour, IObserver<IServerData>, ISlotExhibition,ISubject<ISlotExhibition>
{
    static short[] levelupPoint = { 1, 2, 4, 6, 8, 10 };
    public RelicData _relicData;

    private sRelic _sRelic; 
    private List<Effector> _effectors=new();

    private void Awake()
    {
        foreach (Common.eEffector effectNum in _relicData.EffectNums)
        {
            _effectors.Add(EffectorFactory.Create(effectNum));
        }
        GameManager.Instance._inven.ResistObserver( (short)_relicData.Index,this);
        GameManager.Instance._inven.NotifyObservers((short)_relicData.Index);
    }
    public static UI_Upgrader test;
    public Sprite GiveSprite()
    {
        return _relicData.Sprite;
    }
    public string GiveName()
    {
        return _relicData.Name;
    }

    public void Operate()
    {
        //for(int i =0;i< _effectors.Count;i++)
        //{
        //    _effectors[i].Operate();
        //}
    }

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

    public short GiveLevel()
    {
        return _sRelic.level;
    }

    public short GiveSurplus()
    {
        return _sRelic.surplus;
    }

    List<IObserver<ISlotExhibition>> observers = new();
    public void ResistObserver(IObserver<ISlotExhibition> observer)
    {
        observers.Add(observer);
    }
    public void NotifyObservers()
    {
        foreach (IObserver<ISlotExhibition> observer in observers) { observer.Set(this); };
    }

    public void Set(IServerData data)
    {
        _sRelic.level = data.GiveLevel(); 
        _sRelic.surplus = data.GiveSurplus();

        NotifyObservers();
    }

    public short GiveIndex()
    {
        return (short)_relicData.Index;
    }
}
