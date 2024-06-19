using System;
using System.Collections.Generic;
using UnityEngine;

abstract class AttackDecoTemplate:IAttackDecorator
{
    IAttackDecorator attackDecorator;


    public abstract void AttackEffect();

    public abstract float GetPriority();

    public abstract string GiveExplan(int level);

    public abstract void Operate(int level);

}



