using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingGlasses : CurseDecoTemplate
{


    public override void GetHitEffect(Enemy self, Mercenary attacker, int damage, Debuff debuff)
    {
        _deco.GetHitEffect(self, attacker, Amplification(damage), debuff);
    }

    public int Amplification(int damage)
    {
        if(damage< (3 + _level * 2))
        {
            damage = 3 + _level * 2;
        }
        return damage;
    }
    public override float GetPriority()
    {
        return 25;
    }

    public override string GiveExplan()
    {
        return $"{3+_level*2} 미만의 대미지를 {3 + _level * 2}으로 증폭시킵니다.";
    }

}
