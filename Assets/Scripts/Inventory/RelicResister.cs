using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RelicResister : Singleton<RelicResister>,IObserver<short>,ISlotMenu
{
    short _maxCost;
    short _maxCount;
    
    short _currentCost;
    short _currentCount;

    public List<Relic> _resistedRelics = new();


    [SerializeField]
    UnityEngine.UI.Button _button;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {

            DontDestroyOnLoad(this);
        }

        UI_ClickSlotMenu.Instance.Resist(this);
        _button.onClick.AddListener(() => {
            Relic.CurrentRelic.ChangeState( true);

        });

        GameManager.Instance._battle.ResistObserver(this);

    }

    public void Show(ISlotExhibition purchas)
    {
        _button.gameObject.SetActive(purchas.GiveType()==Common.ePage.eInven);
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

    public void Set(short data)
    {
        int mc = (data / 2) +10;
         _maxCost =  (short)mc;
        int mc2 = (data / 20) + 1;
        _maxCount = (short)mc2;
    }
}
