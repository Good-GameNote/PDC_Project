using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Debuff
{

    private float _damage;

    public void Init(float damage, float durationTime,  Sprite sprite = null)
    {
        _damage = damage;
        base.Init(durationTime, sprite);
    }


    protected override void ContinueAction(float lapse)
    {

        _target.GetDamage((int)(lapse * _damage));
    }

}
