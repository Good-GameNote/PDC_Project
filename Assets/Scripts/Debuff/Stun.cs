using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Stun : Debuff
{


    public Stun( float durationTime, Sprite sprite) : base(durationTime, sprite)
    {
    }

    public override void StartAction(Enemy target)
    {
        _target = target;
        _target.ChangeState(Common.eEnemyState.eStun, 1);
    }

    public override void ContinueAction(float lapse)
    {
    }
    public override void EndAction()
    {
        _target.ChangeState(Common.eEnemyState.eStun, -1);
    }
}
