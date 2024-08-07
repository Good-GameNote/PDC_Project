using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitDecoTemplate : HitEffect
{

    public HitDecoTemplate(HitEffect deco)
    {
        _hitDecos = deco._hitDecos;
        _hitDecos.Enqueue(this);
    }

    public HitDecoTemplate()
    {
    }

    public override void Choice(Mercenary sellectedMercernary)
    {
        sellectedMercernary.UpStarGrade(out HitEffect origin);
        origin = GiveSelf(ref origin);
    }
    protected abstract HitEffect GiveSelf(ref HitEffect deco);
}