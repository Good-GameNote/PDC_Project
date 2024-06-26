using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Debuff
{

    private float _damage;
    public Burn(float damage, float durationTime, Sprite sprite) : base(durationTime, sprite)
    {
        _damage = damage;
    }

    public override void StartAction(Enemy target)
    {
        _target = target;
    }

    public override void ContinueAction(float lapse)
    {

        _target.GetDamage((int)(lapse * _damage));
    }
    public override void EndAction()
    {
    }
}
