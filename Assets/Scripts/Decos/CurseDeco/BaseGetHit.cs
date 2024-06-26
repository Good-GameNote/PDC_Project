
public class BaseGetHit : CurseDecoTemplate
{


    public override void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        self.GetDamage(damage);
        if(debuff!=null)
        {
            self.GetDebuff(debuff);
        }
        _deco.GetHitEffect(self, attacker, (damage), debuff);
       
    }


    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return "";
    }

}
