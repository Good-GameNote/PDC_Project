
public abstract class AttackDecoTemplate : AttackEffect
{

    public AttackDecoTemplate(AttackEffect deco)
    {
        _attackDecos = deco._attackDecos;
        _attackDecos.Enqueue(this);
    }

    public AttackDecoTemplate()
    {
    }

    public override void Choice(Mercenary sellectedMercernary)
    {
        sellectedMercernary.UpStarGrade(out AttackEffect origin);
        origin = GiveSelf(ref origin);
    }
    protected  abstract AttackEffect GiveSelf(ref AttackEffect deco);
}
