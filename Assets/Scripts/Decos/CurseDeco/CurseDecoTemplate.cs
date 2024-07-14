using System;
using System.Collections;
using System.Collections.Generic;
using static Common;

public abstract class CurseDecoTemplate :  CurseEffect
{
    public PriorityQueue<CurseEffect> _curseDecos = new();

    public override void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        _curseDecos.Circuit((deco) => {deco.GetHitEffectDetail(ref self, ref attacker, ref damage, ref debuff );});
    }

    public CurseDecoTemplate(CurseEffect deco)
    {
        _curseDecos.Enqueue(deco);
        _curseDecos.Enqueue(this);
    }
    public CurseDecoTemplate()
    {
    }

    public static CurseEffect GiveCurseEffector()
    {
        CurseEffect curseEffect = new BaseGetHit();

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

