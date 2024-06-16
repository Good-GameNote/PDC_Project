using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicResister : MonoBehaviour,ITownObserver
{
    short _maxCost;
    short _maxCount;
    
    short _currentCost;
    short _currentCount;

    List<Relic> _resistedRelics = new();

    void Start()
    {
        
    }

    // Update is called once per frame


    public void Set(short count, short totalLevel)//ITownObserver
    {
        _maxCount =(short) (count / 2);
        _maxCost =(short)( totalLevel / 3);
    }

    bool ResistRelic(Relic relic)
    {
        if (_currentCost+relic._relicData._cost>_maxCost||_currentCount>=_maxCount)
            return false;
        _currentCount++;
        _currentCost += relic._relicData._cost;
        _resistedRelics.Add(relic);

        return true;
    }
}
