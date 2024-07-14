
using System;
using static Common;
using System.Collections.Generic;
public abstract class Effector :  IComparable<Effector>
{

    protected short _level;

    public abstract string GiveExplan();

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




    public eEffector Index { get; protected set; }

    public abstract void Choice(Mercenary sellected);

    public static Effector[] Effectors = new Effector[] {
        //curse
        new ReadingGlasses() , new Inception(), new Mite(), 
        
        //attack
        new ForkedArrow(),


        //Hit
        new ForkedArrow(),
    };

}