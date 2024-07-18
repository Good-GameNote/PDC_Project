
using UnityEngine;

public class BaseAttack : AttackEffect
{
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
