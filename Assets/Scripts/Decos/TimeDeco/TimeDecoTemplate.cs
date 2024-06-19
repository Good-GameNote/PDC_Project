using System;
using System.Collections.Generic;
using UnityEngine;

abstract class TimeDecoTemplate : ITimeDecorator
{
    ITimeDecorator deco;


    public abstract string GiveExplan(int level);

    
    public abstract void Operate(int level);

    public abstract void TimeEffect();

    public abstract float GetPriority();

    //static IAttackDecorator CreateDeco(int index)
    //{

    //}
}