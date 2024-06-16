using UnityEngine;

[CreateAssetMenu(fileName = "NewRelicData", menuName = "RelicData")]
public class RelicData : ScriptableObject
{
    [field: SerializeField] public int _index { get; private set; }
    [field: SerializeField] public Sprite _sprite { get; private set; }
    [field: SerializeField] public short _cost { get; private set; }
    [field: SerializeField] public string _name { get; private set; }
}