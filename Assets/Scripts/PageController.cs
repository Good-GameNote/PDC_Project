using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour,ISubject<Common.ePage>
{
    Common.ePage _currentPage;

    List<IObserver<Common.ePage>> observers = new();
    public void NotifyObservers()
    {
        foreach(IObserver<Common.ePage> observer in observers )
        {
            observer.Set(_currentPage);
        }
    }

    public void ResistObserver(IObserver<Common.ePage> observer)
    {
        observers.Add(observer);
    }

    public void SetCurrentPage(int page)
    {
        _currentPage = (Common.ePage)page;

        NotifyObservers();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
