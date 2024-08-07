
using System.Collections.Generic;

public class BaseAttack : AttackEffect
{
    public BaseAttack()
    {
        _attackDecos = new();
        _attackDecos.Enqueue(this);
    }
    protected override void AttackDetail(ref List<UnityEngine.Transform> targets,ref List<ProjectileBase> pjt,ref  Mercenary attacker)
    {
        ProjectileBase arrowGO = ProjectilePool.Instance.Get(attacker._mercenaryData.Index, attacker.transform.position);
        arrowGO.Initialize(targets[0], attacker);
        pjt.Add(arrowGO);
    }

    public override void Choice(Mercenary sellected)
    {
        throw new System.NotImplementedException();
    }

    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan(int level)
    {
        throw new System.NotImplementedException();
    }

    public override short GiveIndex()
    {
        return (short)Common.eEffector.MAX_EFFECTOR_SIZE;
    }

    public override string GiveName()
    {
        throw new System.NotImplementedException();
    }

}
