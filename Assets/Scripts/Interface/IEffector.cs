
using System;
using static Common;

public interface IEffector
{
    void Operate(int level);
    string GiveExplan(int level);

    float GetPriority();
}
public static class EffectorFactory
{
    static public IEffector Create(eEffector index)
    {
        throw new NotImplementedException();
    }
}