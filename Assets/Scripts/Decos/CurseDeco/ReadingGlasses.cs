using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingGlasses : CurseDecoTemplate
{
    public ReadingGlasses(CurseEffect deco) : base(deco)
    {
    }
    public ReadingGlasses() : base()
    {
    }

    public int Amplification(int damage)
    {
        if(damage< (3 + _level * 2))
        {
            damage = 3 + _level * 2;
        }
        return damage;
    }
    public override float GetPriority()
    {
        return 25;
    }



    protected override void TakeHitEffectDetail( ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuff)
    {
        damage = Amplification(damage);
    }
    public override short GiveIndex()
    {
        return (short)Common.eEffector.e돋보기;
    }

    public override string GiveExplan(int level)
    {
        return $"{3 + _level * 2} 미만의 대미지를 {3 + _level * 2}으로 증폭시킵니다.";
    }

    public override string GiveName()
    {
        return "돋보기";
    }
}
