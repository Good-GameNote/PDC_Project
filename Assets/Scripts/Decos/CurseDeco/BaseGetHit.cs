
public class BaseGetHit : CurseEffect
{

    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return "";
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
            self.GetDebuff(debuff);
        }
    }
}
