using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicResister : Singleton<RelicResister>,ITownObserver,ISlotMenu
{
    short _maxCost;
    short _maxCount;
    
    short _currentCost;
    short _currentCount;

    List<Relic> _resistedRelics = new();


    [SerializeField]
    UnityEngine.UI.Button _button;
    
    private void Awake()
    {
        UI_ClickSlotMenu.Instance.Resist(this);
        _button.onClick.AddListener(() => {
            Relic.CurrentRelic.ChangeState( true);

        });

        GameManager.Instance._town.ResistObserver(this);

    }
    public void Show(ISlotExhibition purchas)
    {
        _button.gameObject.SetActive(purchas.GiveType()==Common.ePage.eInven);
    }


    public void Set(short count, short totalLevel)//ITownObserver
    {
        _maxCount =(short) (count / 2);
        _maxCost =(short)( totalLevel / 3);
    }

    public Common.All_ERROR ResistRelic(Relic relic, bool sendPacket)
    {
        if (sendPacket)
        {
            if (_currentCost+relic._relicData.Cost>_maxCost)
                return Common.All_ERROR.eLackCost;
            if (_currentCount >= _maxCount)
                return Common.All_ERROR.eLackSlot;
        }

        _currentCount++;
        _currentCost += relic._relicData.Cost;

        _resistedRelics.Add(relic);
        return Common.All_ERROR.eSuccess;
    }

    public void DereRelic(Relic relic)
    {
        if (!_resistedRelics.Contains(relic))
            return;

        _currentCount--;
        _currentCost -= relic._relicData.Cost;

        _resistedRelics.Remove(relic);        
    }

}
