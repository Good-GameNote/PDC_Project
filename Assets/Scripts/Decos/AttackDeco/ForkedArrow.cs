using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkedArrow : AttackDecoTemplate
{
    public ForkedArrow(AttackEffect deco) : base(deco)    {    }
    public ForkedArrow() : base()    {    }

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
        return $"공격시 대상 주변 적에게 추가 화살을 발사합니다.";
    }


    public override string GiveName()
    {
        return "갈래화살";
    }

    protected override AttackEffect GiveSelf(ref AttackEffect deco)
    {
        return new ForkedArrow(deco);
    }

    protected override void AttackDetail(ref List<Transform> targets, ref List<ProjectileBase> pjt, ref Mercenary attacker)
    {
        IStat_AddPjt add = attacker._mercenaryData as IStat_AddPjt;
        for (int i = 1; i < add.AddPjtCount.Value; i++)
        {
            ProjectileBase arrowGO = ProjectilePool.Instance.Get(attacker._mercenaryData.Index, attacker.transform.position);
            arrowGO.Initialize(targets[i], attacker);
            pjt.Add(arrowGO);           
        }
    }
}
