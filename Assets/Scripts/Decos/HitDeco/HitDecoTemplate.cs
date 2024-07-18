using System;
using System.Collections.Generic;
using UnityEngine;

abstract class HitDecoTemplate : HitEffect
{


    //public abstract string GiveExplan(int level);

    public abstract void HitEffect();

    public abstract void Operate(int level);



    //static IAttackDecorator CreateDeco(int index)
    //{

    //}
}