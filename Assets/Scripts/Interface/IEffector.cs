
public interface IEffector
{
    void Operate(int level);
    string GiveExplan(int level);

    float GetPriority();
}
