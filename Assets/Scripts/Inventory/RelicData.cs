using UnityEngine;
using static Common;

[CreateAssetMenu(fileName = "NewRelicData", menuName = "RelicData")]
public class RelicData : ScriptableObject, ICanExhibition
{
    [field: SerializeField] public eRelic Index { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public short Cost { get; private set; }
    [field: SerializeField] public eEffector EffectNum {  get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    public short GiveIndex()
    {
        return (short)Index;
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