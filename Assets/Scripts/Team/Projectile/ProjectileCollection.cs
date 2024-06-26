using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : ProjectileBase
{
    public void Initialize(int damage)
    {
        this.damage = damage;
        _canAirAttack = true;
    }

    public override void Launch()
    {
        // FireBall 발사 로직
    }
}

public class IceArrow : ProjectileBase
{
    public void Initialize(int damage)
    {
        this.damage = damage;
        _canAirAttack = true;
    }

    public override void Launch()
    {
        // IceBall 발사 로직
    }
}
