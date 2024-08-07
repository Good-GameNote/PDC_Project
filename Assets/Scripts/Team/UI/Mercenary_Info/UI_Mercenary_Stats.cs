using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mercenary_Stats : ObjectPool<UI_Mercenary_Stat>
{
    [SerializeField]
    Transform[] _pages;

    List<UI_Mercenary_Stat>[] _statsByPage;

    protected override void Awake()
    {
        base.Awake();
        _statsByPage = new List<UI_Mercenary_Stat>[_pages.Length];

        for (int i =0; i< _pages.Length; i++)
        {
            _statsByPage[i]= new List<UI_Mercenary_Stat>();

        }
    }
    public void Set(UpStatData[] StatsByLevel)
    {
        foreach (var slots in _statsByPage)
        {
            while (slots.Count > 0)
            {
                UI_Mercenary_Stat slot = slots[0];
                slots.RemoveAt(0);
                Release(slot, 0);
            }
            
        }

        foreach (var t in StatsByLevel)
        {
            Add(t._stat);
        }

    }

    private void Add(Stat StatByLevel)
    {
        bool result= false;
        foreach(UI_Mercenary_Stat stat in _statsByPage[StatByLevel.Page] )//
        {

            if (result = stat.IsMatch(StatByLevel.Icon))
            {
                stat.SetData(StatByLevel.Icon, StatByLevel.Value.ToString());
                break;
            }
        }

        if(result==false)
        {
            UI_Mercenary_Stat stat=  Get(Vector3.zero);
            stat.SetData(StatByLevel.Icon, StatByLevel.Value.ToString());

            _statsByPage[StatByLevel.Page].Add(stat);
            stat.transform.SetParent(_pages[StatByLevel.Page], false);

        }

    }


}
