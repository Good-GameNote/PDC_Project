using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkedArrow : AttackDecoTemplate
{
    public ForkedArrow(AttackEffect deco) : base(deco)
    {
    }
    public ForkedArrow() : base()
    {
    }

    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return $"적을 .";
    }



}
