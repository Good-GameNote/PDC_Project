using System;
using System.Collections;
using System.Collections.Generic;
using static Common;

public abstract class CurseDecoTemplate :  CurseEffect
{
 

    public CurseDecoTemplate(CurseEffect deco)
    {
        _curseDecos = deco._curseDecos;
        _curseDecos.Enqueue(this);
    }
    public CurseDecoTemplate()
    {
    }

    public static CurseEffect GiveCurseEffector()
    {
        CurseEffect curseEffect = new BaseTakeHit();

        foreach (Relic r in RelicResister.Instance._resistedRelics)
        {
            eEffector num = r._relicData.EffectNum;

            switch (num)
            {
                case eEffector.e돋보기: 
                    curseEffect = new ReadingGlasses( curseEffect);
                    break;
                case eEffector.e인셉션:
                    curseEffect = new Inception(curseEffect);
                    break;
                case eEffector.e10퍼추댐:
                    curseEffect = new Mite(curseEffect);
                    break;

            }
        }

        return curseEffect;
    }


}

