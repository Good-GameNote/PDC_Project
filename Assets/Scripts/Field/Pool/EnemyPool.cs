using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField]
    Enemy[] Enemys;

    private void Awake()
    {
        EnemyData[] datas = GameManager.Instance._battle.sellectStage.Enemys;
        Enemy[] curStageEnemys = new Enemy[datas.Length];
        for (int i =0; i< datas.Length; i++)
        {
            curStageEnemys[i] = Enemys[datas[i].Index];
        }
        Init(curStageEnemys );

    }




}
