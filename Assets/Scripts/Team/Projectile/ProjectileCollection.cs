using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : ProjectileBase
{
    [SerializeField]
    private Sprite _fireArrowEffect;
    [SerializeField]
    private Sprite _fireArrowSplashEffect;

    public void Initialize(int damage)
    {
        this.damage = damage;
        AfterLaunch();
    }

    public override void AfterLaunch()
    {

    }
}

public class IceArrow : ProjectileBase
{
    [SerializeField]
    private Sprite _iceArrowEffect;
    [SerializeField]
    private Sprite _iceArrowSplashEffect;

    public void Initialize(int damage)
    {
        this.damage = damage;
    }

    public override void AfterLaunch()
    {
        throw new System.NotImplementedException();
    }
}
