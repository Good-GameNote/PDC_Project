
public interface IObserver<T>
{
    void Set(T data);
}


public interface ITownObserver
{
    void Set(short count, short totalLevel);
}

