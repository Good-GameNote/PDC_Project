using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : Singleton<PageController>,ISubject<Common.ePage>
{

    List<IObserver<Common.ePage>> observers = new();
    public void NotifyObservers(Common.ePage data)
    {
        foreach(IObserver<Common.ePage> observer in observers )
        {
            observer.Set(data);
        }
    }

    public void ResistObserver(IObserver<Common.ePage> observer)
    {
        observers.Add(observer);
    }

    public void SetCurrentPage(Common.ePage page)
    {

        NotifyObservers(page);
    }


}
