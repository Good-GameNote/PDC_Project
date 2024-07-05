using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inception : CurseDecoTemplate
{

    public override void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        if (debuff != null)
        {
            Stun stun = debuff as Stun;
            if (stun != null)
            {
                if (Random.Range(0, 100000) < 5000)
                {
                    self.SetInitPosition( );
                }

            }
        }
        _deco.GetHitEffect(self, attacker, damage, debuff);
    }

    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return $"적을 기절시킬때 5%확률로 처음 위치로 돌려보냅니다.";
    }

}
