
using System.Collections.Generic;

public interface ISubject<T>
{
    void ResistObserver(IObserver<T> observer);
    void NotifyObservers(T data);
}

public interface ITownSubject
{
    void ResistObserver(ITownObserver observer);
    void NotifyObservers();
}

public interface IIndexableSubject<T>
{
    void ResistObserver(short index,IObserver<T> observer);
    void NotifyObservers(short index);
}