﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mite : CurseDecoTemplate
{
    public Mite(CurseEffect deco) : base(deco)
    {
    }

    public override void GetHitEffectDetail(ref Enemy self,ref Mercenary attacker, ref int damage,ref Debuff debuff)
    {
        if (self._HP == self._enemyData.HP)
        {
            damage = (int)(damage * 1.1f);
        }
    }

    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return $"체력이 가득찬 적이 10% 강한 피해를 입습니다.";
    }

}
