using System;
using System.Collections.Generic;
using UnityEngine;

public struct UpStatData 
{
    bool[] _UpStatChecking;
    public UpStatData( bool[] UpStatChecking,string explan, Action excute, Stat stat)
    {
        _UpStatChecking = UpStatChecking;
        _explan = explan;
        _excute = excute;
        _stat = stat;
    }
    public string _explan;
    public void Excute(int idx)
    {
        if (!_UpStatChecking[idx])
        {
            _excute();
            _UpStatChecking[idx] = true;
        }
    }

    private Action _excute;

    public Stat _stat;
}

[Serializable]
public class Stat 
{
    [field: SerializeField] public Sprite Icon { get; protected set; }
    public int Value;
    [field: SerializeField] public short Page { get; protected set; }
}

public class MercenaryData : ScriptableObject,ICanExhibition
{
    [field: SerializeField] public short Index { get; private set; }
    [field: SerializeField] public Stat CoolTime { get; protected set; }
    [field: SerializeField] public Stat Range { get; protected set; }
    [field: SerializeField] public Stat Damage { get; protected set; }
    [field: SerializeField] public Stat CriticalPer { get; protected set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; protected set; }
    [field: SerializeField] public Sprite Sprite { get; protected set; }
    [field: SerializeField] public Common.eEnemyState[] ThingCanSee { get; protected set; }
    public UpStatData[] StatsByLevel { get; protected set; }

    protected bool[] UpStatChecking = new bool[20];
    public short GiveIndex()
    {
        return Index;
    }

    public string GiveName()
    {
        return Name;
    }

    public Sprite GiveSprite()
    {
        return Sprite;
    }


    public List <ICardExhibition>[] _characteristic = new List<ICardExhibition>[]
    {
        new List<ICardExhibition>() ,
        new List<ICardExhibition>() ,
        new List<ICardExhibition>(),
    };
 


}
