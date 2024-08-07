
using System.Collections.Generic;

public class BaseTakeHit : CurseEffect
{
    public BaseTakeHit()
    {
        _curseDecos = new();
        _curseDecos.Enqueue(this);
    }
    public override float GetPriority()
    {
        return 25;
    }


    protected override void TakeHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuffs)
    {
        self.TakeDamage(damage);
        foreach (var debuff in debuffs)
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
