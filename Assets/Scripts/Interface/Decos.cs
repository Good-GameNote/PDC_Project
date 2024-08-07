using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitEffect : Effector
{
    public PriorityQueue<HitEffect> _hitDecos;

    public void GiveHitEffect(Enemy self, Mercenary attacker, int damage, List<Debuff> debuff)
    {
        _hitDecos.Circuit((deco) => { deco.GiveHitEffectDetail(ref self, ref attacker, ref damage, ref debuff); });
    }
    protected abstract void GiveHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuff);

}

public abstract class AttackEffect:Effector
{
    public PriorityQueue<AttackEffect> _attackDecos;

    public void Attack(List<Transform> targets, List<ProjectileBase> pjt, Mercenary attacker)
    {
        _attackDecos.Circuit((deco) => { deco.AttackDetail(ref  targets, ref  pjt, ref  attacker); });

    }

    protected abstract void AttackDetail(ref List<Transform> targets,ref List<ProjectileBase> pjt,ref Mercenary attacker);

}

public abstract class CurseEffect:Effector
{

    public PriorityQueue<CurseEffect> _curseDecos;

    public void TakeHitEffect(Enemy self, Mercenary attacker, int damage, List<Debuff> debuff)
    {
        _curseDecos.Circuit((deco) => { deco.TakeHitEffectDetail(ref self, ref attacker, ref damage, ref debuff); });
    }
    protected abstract void TakeHitEffectDetail(ref Enemy self, ref Mercenary attacker, ref int damage, ref List<Debuff> debuff);

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
