
public abstract class AttackDecoTemplate : AttackEffect
{
    public PriorityQueue<AttackEffect> _curseDecos = new();

    public AttackDecoTemplate(AttackEffect deco)
    {
        _curseDecos.Enqueue(deco);
        _curseDecos.Enqueue(this);
    }

    public AttackDecoTemplate()
    {
    }

    public override void Choice(Mercenary sellectedMercernary)
    {
        sellectedMercernary.UpStarGrade(out AttackEffect origin);
        origin = new ForkedArrow(origin);
    }

}
