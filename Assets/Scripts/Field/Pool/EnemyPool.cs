using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    [SerializeField]
    Enemy[] Enemeys;

    private void Awake()
    {

        prefabs = new Enemy[]
        {

        };
    }




}
