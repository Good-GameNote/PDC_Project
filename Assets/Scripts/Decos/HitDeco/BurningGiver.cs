using System;
using System.Collections.Generic;


public class BurningGiver : HitDecoTemplate
{
    public BurningGiver(HitEffect deco) : base(deco)    {    }
    public BurningGiver() : base()    {    }

    public override float GetPriority()    {        return 5;    }



    protected override void GiveHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuffs)
    {
        IStat_DebuffRate rate = attacker._mercenaryData as IStat_DebuffRate;
        if (UnityEngine.Random.Range(0, 100000) < rate.DebuffRate.Value*100)
        {
            Burn burn = DebuffPool.Instance.Get((int)Common.eDebuff.eBurn,UnityEngine.Vector3.zero) as Burn;
            burn.Init(10,10);//화상 효과정해지면 수정필요
            debuffs.Add(burn);
        }
    }

    public override short GiveIndex()
    {
        return (short)Common.eEffector.e화염묻히기;
    }

    public override string GiveExplan(int level)
    {
        return $"적중시 30% 확률로 화상을 입힙니다.";
    }


    public override string GiveName()
    {
        return "화염묻히기";
    }

    protected override HitEffect GiveSelf(ref HitEffect deco)
    {
        return new BurningGiver(deco);
    }
}

