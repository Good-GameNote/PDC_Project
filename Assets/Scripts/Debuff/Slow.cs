using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Debuff
{

    private float _speedReductionRate;

    private float _fixedSpeedReduction;

    public void Init(float speedReductionRate, float fixedSpeedReduction, float durationTime,  Sprite sprite = null)
    {
        _speedReductionRate = speedReductionRate;
        _fixedSpeedReduction = fixedSpeedReduction;
        base.Init(durationTime, sprite);

    }


    protected override void StartAction()
    {
        _target.ChangeMoveSpeed(_speedReductionRate, _fixedSpeedReduction);
    }


    protected override void EndAction()
    {
        _target.ChangeMoveSpeed(-_speedReductionRate, -_fixedSpeedReduction);
    }

    protected override Common.eDebuff GiveType()
    {
        return Common.eDebuff.eSlow;
    }
}
