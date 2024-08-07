using System;
using System.Collections.Generic;

public class BaseGiveHit : HitEffect
{
    public BaseGiveHit()
    {
        _hitDecos = new();
        _hitDecos.Enqueue(this);
    }
    public override void Choice(Mercenary sellected)
    {
        throw new NotImplementedException();
    }

    public override float GetPriority()
    {
        throw new NotImplementedException();
    }

    public override string GiveExplan(int level)
    {
        throw new NotImplementedException();
    }

    protected override void GiveHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuff)
    {
        throw new NotImplementedException();
    }

    public override short GiveIndex()
    {
        throw new NotImplementedException();
    }

    public override string GiveName()
    {
        throw new NotImplementedException();
    }
}
/*
 
        for (int i = 0; i < _findingTargets.Count; i++)
        {
            if(_findingTargets[i]==null) continue;

            
            _findingTargets[i].TakeHit(_mercenary,_damage,_debuffList );
        

        }
 
 */