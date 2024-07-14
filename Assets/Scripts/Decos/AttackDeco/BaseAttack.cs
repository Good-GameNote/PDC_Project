
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

    public override string GiveExplan()
    {
        return "";
    }
 
}
