using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFactory
{
    static ICurseDecorator _curseDecorator;

    static public void SetDeco(ICurseDecorator curseDecorator)
    {
        _curseDecorator = curseDecorator;
    }
}
public abstract class CurseDecoTemplate: Effector, ICurseDecorator
{
    protected ICurseDecorator _deco;

    protected static PriorityQueue<CurseDecoTemplate> _CurseDecos = new();


    public override void SetDeco(IDeco deco)
    {
        _deco = (ICurseDecorator)deco;
    }


    public virtual void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        _deco.GetHitEffect(self, attacker, damage, debuff);
    }
    public override void Resist()
    {
        
        _CurseDecos.Enqueue(this);
    }
    public override void DeResist()
    {
        _CurseDecos.Remove(this);
    }
    public override Effector GiveDeco()
    {
        if (_CurseDecos.Count < 1)
        {
            _CurseDecos.Enqueue(new BaseGetHit());
        }
        Effector deco = null;
        
        _CurseDecos.Circuit((other) =>
        {
            Effector part = EffectorFactory.Create(other._index);
            if(deco==null)
            {
                deco = part;
            }else
            {
                deco.SetDeco(part);
            }
        });
        
        return deco;
    }

}

