
using UnityEditor.Build.Pipeline;

public interface IHitDecorator : IEffector
{
    void HitEffect();
}

public interface IAttackDecorator: IEffector
{
    void AttackEffect();
}


public interface ITimeDecorator : IEffector
{
    void TimeEffect();
}

public interface ICurseDecorator : IEffector
{
    void GetHitEffect();
}

public interface IDefenceDecorator : IEffector
{
    void DefenceEffect();
}
