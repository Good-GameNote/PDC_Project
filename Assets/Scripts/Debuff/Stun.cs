using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : Debuff
{
    public new void Init( float durationTime, Sprite sprite = null) 
    {
        base.Init(durationTime, sprite);

    }

    protected override void StartAction()
    {
        _target.ChangeState(Common.eEnemyState.eStun, 1);
    }


    protected override void EndAction()
    {
        _target.ChangeState(Common.eEnemyState.eStun, -1);
    }

    protected override Common.eDebuff GiveType()
    {
        return Common.eDebuff.eStun;
    }
}
