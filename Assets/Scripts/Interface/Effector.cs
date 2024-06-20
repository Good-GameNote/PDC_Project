
using System;
using static Common;
using System.Collections.Generic;

public abstract class Effector:IComparable<Effector>,IDeco
{
    public eEffector _index { get; protected set; }

    protected short _level;

    public void SetLevel(short level)
    {
        _level = level;
    }

    public abstract void Resist();
    public abstract Effector GiveDeco();

    //static PriorityQueue<ICurseDecorator> _queue = new();
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
    public abstract void SetDeco(IDeco deco);
}
public static class EffectorFactory
{
    static public Effector Create(eEffector index)
    {
        switch (index)
        {
            case eEffector.e돋보기: return new ReadingGlasses();
        }
        return null;
    }
}