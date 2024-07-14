using System;

public abstract class HitEffect : Effector
{
    public override void Choice(Mercenary effect)
    {

    }
}

public abstract class AttackEffect:Effector
{



}

public abstract class CurseEffect:Effector
{
    public abstract void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff);
    public abstract void GetHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref Debuff debuff);

    public override void Choice(Mercenary effect)
    {
        throw new System.NotImplementedException();
    }
}


public interface ITimeDecorator 
{
    void TimeEffect();
}


public interface IDefenceDecorator 
{
    void DefenceEffect();
}
