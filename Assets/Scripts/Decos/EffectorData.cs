using System;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "NewEffectorData", menuName = "EffectordData")]

class EffectorData : ScriptableObject
{
    [field: SerializeField]
    public Common.eEffector Idx { get; private set; }
    [field: SerializeField]
    public string Name { get; private set; }
    //[field: SerializeField]
    //public string Explane { get; private set; }
    [field: SerializeField]
    public Sprite Sprete { get; private set; }


}