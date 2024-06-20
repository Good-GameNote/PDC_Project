
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    EnemyData _enemyData;
    ICurseDecorator _curseDeco;

    int _hp;
    public void GetDamage(int damage)
    {
        _hp -= damage;
        if ( _hp < 0 )
        {
            _hp = 0;
        }
    }
    List<Debuff> debuffs = new ();
    public void GetDebuff(Debuff debuff)
    {
        debuffs.Add( debuff );
        debuff.StartAction(this);
    }
    public void RemoveBuff(Debuff target)
    {
        target.EndAction();
        debuffs.Remove( target );
    }

    ICurseDecorator _curseDecorator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach ( Debuff debuff in debuffs )
        {
            debuff.Activation();
        }
    }
}
