using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : ProjectileBase
{
    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    public override void EnemyTarget()
    {
        // FireBall 발사 로직
    }
}

public class IceArrow : ProjectileBase
{
    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    public override void EnemyTarget()
    {
        // IceBall 발사 로직
    }
}
