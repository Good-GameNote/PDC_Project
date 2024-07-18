using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewRewardData", menuName = "RewardData")]
public class Reward : ScriptableObject, ICardExhibition
{
    [field: SerializeField]
    public Common.eMoney Type { get; private set; }

    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public Sprite sprite { get; private set; }
    [field: SerializeField]
    public int Value { get; private set; }
    [field: SerializeField]
    public short Balance { get; private set; }

    public void SetValue(float value)
    {
        Value = (int)(value * Random.Range(0.8f,1.2f)* Balance);
    }
    public string GiveExplan(int level)
    {
        return $"{GiveName()}를 {Value} 획득합니다.";

    }

    public short GiveIndex()
    {
        return (short)Type;
    }

    public string GiveName()
    {
        return Name;
    }

    public Sprite GiveSprite()
    {
        return sprite;
    }
}
