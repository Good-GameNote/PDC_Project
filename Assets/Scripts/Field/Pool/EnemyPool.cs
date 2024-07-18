using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{

    protected override void Awake()
    {
        base.Awake();
        EnemyData[] datas = GameManager.Instance._battle.sellectStage.Enemys;//스테이지에 나올애들 추림
        short[] usingIdx = new short[datas.Length];
        for (int i =0; i< datas.Length; i++)
        {
            usingIdx[i] =(short) datas[i].Index;
        }

        LimitPool(usingIdx);



    }
}
