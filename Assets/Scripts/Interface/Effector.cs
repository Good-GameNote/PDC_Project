
using System;
using static Common;
using System.Collections.Generic;
using UnityEngine;
public abstract class Effector :  IComparable<Effector>,ICardExhibition
{

    protected short _level;

    public abstract float GetPriority();


    public int CompareTo(Effector other)//값이 작으면 우선순위가 높음
    {
        float value = GetPriority() - other.GetPriority();
        int result = 0;
        if (value < 0)
        {
            result = -1;
        }
        else if (value > 0)
        {
            result = 1;
        }
        return result;
    }




    public abstract void Choice(Mercenary sellected);

    public abstract string GiveExplan(int level);

    public Sprite GiveSprite()
    {
        return GameManager.Instance._addressableLoader.GetLoadedResource<Sprite>(GiveName());
    }

    public abstract string GiveName();

    public abstract short GiveIndex();

    public static Effector[] Effectors = new Effector[] {
        //curse
        new ReadingGlasses() , new Inception(), new Mite(), 
        
        //attack
        new ForkedArrow(),


        //Hit
        new BurningGiver(),
    };

}