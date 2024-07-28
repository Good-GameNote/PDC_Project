using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "NewMercenaryData", menuName = "MercenaryData")]
public class MercenaryData : ScriptableObject,ICanExhibition
{
    [field: SerializeField] public short Index { get; private set; }
    [field: SerializeField] public int EnchantLevel { get; private set; }
    [field: SerializeField] public float CoolTime { get; private set; }
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int CriticalPer { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public Common.eEnemyState[] ThingCanSee { get; private set; }

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
}
