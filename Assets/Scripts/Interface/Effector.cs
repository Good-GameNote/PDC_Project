
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



    public static void Resist(eEffector num , eEffector[] group, List<eEffector> resistedNums)
    {
        foreach (eEffector e in group)
        {
            if (e == num)
            {
                resistedNums.Add(num);
            }
        }
    }

    public static void DeResist(List<eEffector> resistedNums, eEffector index)
    {
        resistedNums.Remove(index);
    }

    //public static void Choice(eEffector num, eEffector[] group,  Effector effect)
    //{
    //    //A 데코인지 H데코인지 판단 
    //    foreach (eEffector e in group)
    //    {
    //        if (e == num)
    //        {
    //            effect
    //        }
    //    }
    //}


}