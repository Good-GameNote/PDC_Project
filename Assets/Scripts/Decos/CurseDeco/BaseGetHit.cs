
using UnityEngine;

public class BaseGetHit : CurseEffect
{

    public override float GetPriority()
    {
        return 25;
    }



    public override void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        GetHitEffectDetail(ref self, ref attacker, ref damage, ref debuff);
    }

    public override void GetHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref Debuff debuff)
    {
        self.GetDamage(damage);
        if (debuff != null)
        {
            debuff.Excute(self);
        }
    }

    public override short GiveIndex()
    {
        return (short)Common.eEffector.MAX_EFFECTOR_SIZE;
    }

    public override string GiveExplan(int level)
    {
        throw new System.NotImplementedException();
    }


    public override string GiveName()
    {
        throw new System.NotImplementedException();
    }
}
