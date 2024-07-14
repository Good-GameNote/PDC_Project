using System;
using System.Collections.Generic;
using UnityEngine;

abstract class DefenceDecoTemplate 
{


    public abstract string GiveExplan(int level);

    public abstract void HitEffect();

    public abstract void Operate(int level);

    public abstract float GetPriority();


}