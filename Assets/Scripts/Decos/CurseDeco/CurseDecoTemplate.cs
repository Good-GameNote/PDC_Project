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
        if (_CurseDecos.Count < 1)
        {
            _CurseDecos.Enqueue(new BaseGetHit());
        }
        _CurseDecos.Enqueue(this);
    }
    public override Effector GiveDeco()
    {
        Effector deco = null;
        if (_CurseDecos.Count > 0)
        {
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
        }

        return deco;

    }

}

