using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Mercenary_Detale : Singleton<UI_Mercenary_Detale>
{
    [SerializeField]
    UI_Mercenary_Top _top;
    [SerializeField]
    UI_Mercenary_Stats _stats;
    [SerializeField]
    UI_UpStatSlot[] _slots;

    UI_Mercenary _sellected;


    public void Sellect(UI_Mercenary data)
    {
        gameObject.SetActive(true);
        _sellected = data;
        _top.SetTop(_sellected._uiData);
        for(int i = 0; i<_sellected._mercenaryData.StatsByLevel.Length;i++)
        {
            _slots[i].Set(_sellected._mercenaryData.StatsByLevel[i], i, _sellected._uiData.GiveLevel());
        }

        _stats.Set(_sellected._mercenaryData.StatsByLevel);
    
    }


}
