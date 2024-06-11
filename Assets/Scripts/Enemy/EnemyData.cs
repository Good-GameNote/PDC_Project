using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int _index { get; private set; }
    [field: SerializeField] public bool _isAir { get; private set; }
    [field: SerializeField] public int _HP { get; private set; }
    [field: SerializeField] public float _Speed { get; private set; }
    [field: SerializeField] public string _name { get; private set; }
    [field: SerializeField] public string _description { get; private set; }
    [field: SerializeField] public Sprite _sprite { get; private set; }

}