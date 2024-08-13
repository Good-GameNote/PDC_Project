using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catsle : Singleton<Catsle>
{
    [SerializeField]
    short HP;

    short MaxHP = 1555;
    
    // Start is called before the first frame update
    public void Init(Transform point)
    {
        HP = MaxHP;
        point = point.GetChild(0).GetChild(0);
        transform.position = point.position;

    }
    LayerMask enemyLayer = 1<<(int)Common.eLayer.Enemy;
    Enemy enemy;
    [SerializeField]
    UI_End _ender;
    private void OnTriggerEnter(Collider other)
    {
        //적에 충돌하지않으면 필터
        if ((enemyLayer.value & (1 << other.gameObject.layer)) == 0)        
            return;        
        Debug.Log("공격받음" );
        HP--;
        other.gameObject.TryGetComponent(out enemy);
        EnemyPool.Instance.Release(enemy, enemy._enemyData.Index);
        if (HP<=0)
        {
            Debug.Log("클리어 실패");
            _ender.IsClear();
        }
    }
    public short GiveAchivement()
    {
        if (HP>=MaxHP)
        {
            return 3;
        }else if (HP>= MaxHP/2)
        { 
            return 2;
        }else 
        {
            return 1;
        }
    }
}
