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


    public static eEffector[] curseNums = new eEffector[] {eEffector.e돋보기 };

    public static List<eEffector> resistedNums = new ();


    public static CurseEffect GiveCurseEffector()
    {
        CurseEffect curseEffect = new BaseGetHit();

        foreach (eEffector num in resistedNums)
        {
            switch (num)
            {
                case eEffector.e돋보기: curseEffect = new ReadingGlasses( curseEffect);
                    break;


            }
        }

        return curseEffect;
    }


}

