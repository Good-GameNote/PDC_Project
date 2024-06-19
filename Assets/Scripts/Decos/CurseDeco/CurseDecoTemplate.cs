using System;
using System.Collections.Generic;
using UnityEngine;

abstract class CurseDecoTemplate: ICurseDecorator
{
    ICurseDecorator deco;

    public abstract void GetHitEffect();

    public abstract string GiveExplan(int level);

    public abstract void Operate(int level);

    public abstract float GetPriority();


    //static IAttackDecorator CreateDeco(int index)
    //{

    //}
}

