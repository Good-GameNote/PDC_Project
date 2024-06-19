using UnityEngine;
using static Common;

[CreateAssetMenu(fileName = "NewRelicData", menuName = "RelicData")]
public class RelicData : ScriptableObject
{
    [field: SerializeField] public eRelic Index { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public short Cost { get; private set; }
    [field: SerializeField] public eEffector[] EffectNums {  get; private set; }
    [field: SerializeField] public string Name { get; private set; }

}