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


    public override short GiveIndex()
    {
        return (short)Common.eEffector.e갈래화살;
    }

    public override string GiveExplan(int level)
    {
        return "공격시 대상 주변 적에게 한발더 발사합니다.";
    }


    public override string GiveName()
    {
        return "갈래화살";
    }
}
