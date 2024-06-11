using System;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "NewMercenaryData", menuName = "MercenaryData")]
public class MercenaryData : ScriptableObject
{
    [field: SerializeField] public int _index { get; private set; }
    [field: SerializeField] public float _coolTime { get; private set; }
    [field: SerializeField] public float _range { get; private set; }
    [field: SerializeField] public float _damage { get; private set; }
    [field: SerializeField] public int _criticalPer { get; private set; }
    [field: SerializeField] public string _name { get; private set; }
    [field: SerializeField] public string _description { get; private set; }
    [field: SerializeField] public Sprite _sprite { get; private set; }

}
