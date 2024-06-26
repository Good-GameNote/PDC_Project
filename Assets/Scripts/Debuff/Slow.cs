using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : Debuff
{

    private float _speedReductionRate;

    private float _fixedSpeedReduction;
    public Slow(float speedReductionRate, float fixedSpeedReduction, float durationTime, Sprite sprite) : base(durationTime,sprite )
    {
        _speedReductionRate = speedReductionRate;
        _fixedSpeedReduction = fixedSpeedReduction;
    }

    public override void StartAction(Enemy target)
    {
        _target = target;
        _target.ChangeMoveSpeed(_speedReductionRate, _fixedSpeedReduction);
    }

    public override void ContinueAction(float lapse)
    {
    }
    public override void EndAction()
    {
        _target.ChangeMoveSpeed(-_speedReductionRate, -_fixedSpeedReduction);
    }
}
