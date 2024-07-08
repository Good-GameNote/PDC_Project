using System;

public interface IHitDecorator 
{
    void HitEffect();
}

public interface IAttackDecorator
{
    void AttackEffect();
}

public abstract class CurseEffect:Effector
{
    
    public abstract void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff);
    public abstract void GetHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref Debuff debuff);

}


public interface ITimeDecorator 
{
    void TimeEffect();
}


public interface IDefenceDecorator 
{
    void DefenceEffect();
}
