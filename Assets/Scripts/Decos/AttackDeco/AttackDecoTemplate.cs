using System;
using System.Collections;
using System.Collections.Generic;
using static Common;

public abstract class AttackDecoTemplate : AttackEffect
{
    public PriorityQueue<AttackEffect> _curseDecos = new();

    public AttackDecoTemplate(AttackEffect deco)
    {
        _curseDecos.Enqueue(deco);
        _curseDecos.Enqueue(this);
    }


    public static eEffector[] curseNums = new eEffector[] { eEffector.e갈래화살 };

    public static AttackEffect GiveCurseEffector()
    {
        return null;
    }


}
