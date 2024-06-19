using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [field: SerializeField] public int Index { get; private set; }
    [field: SerializeField] public bool IsAir { get; private set; }
    [field: SerializeField] public int HP { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

}