using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewStageData", menuName = "StageData")]

public class Stage : ScriptableObject
{
    [field:SerializeField]
    public EnemyData[] Enemys { get; private set; }

    [field: SerializeField]
    public Common.eMoney[] Rewards { get; private set; }

    public sStage stage;
    
}
