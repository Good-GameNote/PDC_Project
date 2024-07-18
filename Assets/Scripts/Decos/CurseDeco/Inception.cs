
using UnityEngine;

public class Inception : CurseDecoTemplate
{
    public Inception(CurseEffect deco) : base(deco)
    {
    }
    public Inception() : base()
    {
    }

    public override float GetPriority()
    {
        return 25;
    }



    public override void GetHitEffectDetail(ref Enemy self,ref Mercenary attacker,ref int damage,ref Debuff debuff)
    {
        if (debuff != null)
        {
            Stun stun = debuff as Stun;
            if (stun != null)
            {
                if (Random.Range(0, 100000) < 5000)
                {
                    self.SetInitPosition();
                }

            }
        }
    }

    public override short GiveIndex()
    {
        return (short)Common.eEffector.e인셉션;
    }

    public override string GiveExplan(int level)
    {
        return $"적을 기절시킬때 5%확률로 처음 위치로 돌려보냅니다.";
    }


    public override string GiveName()
    {
        return "인셉션";
    }
}
