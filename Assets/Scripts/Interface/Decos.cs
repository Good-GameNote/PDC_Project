
public interface IHitDecorator
{
    void HitEffect();
}

public interface IAttackDecorator
{
    void AttackEffect();
}

public interface ITimeDecorator
{
    void TimeEffect();
}

public interface ICurseDecorator
{
    void GetHitEffect();
}

public interface IDefenceDecorator
{
    void DefenceEffect();
}
