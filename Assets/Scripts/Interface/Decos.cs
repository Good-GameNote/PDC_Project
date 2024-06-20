

public interface IDeco
{
    void SetDeco(IDeco deco);
}
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
public interface ICurseDecorator : IDeco
{
    abstract void GetHitEffect(Enemy self, Mercenary attacker , int damage ,Debuff debuff );
}

public interface IDefenceDecorator 
{
    void DefenceEffect();
}
