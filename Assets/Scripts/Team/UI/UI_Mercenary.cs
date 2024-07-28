using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_Mercenary : MonoBehaviour, IObserver<sMercenary[]>, ISubject<ISlotExhibition>
{
    [SerializeField]
    public MercenaryData _mercenaryData;

    sMercenary[] _sMercenary;

    ISlotExhibition _uiData;

    private void Awake()
    {
        GameManager.Instance._team.ResistObserver((short)_mercenaryData.Index, this);
        UnityEngine.UI.Button _button = gameObject.AddComponent<UnityEngine.UI.Button>();
        _button.onClick.AddListener(() => { UI_ClickSlotMenu.Instance.ClickThis(transform, _uiData); });
    }
    public void Set(sMercenary[] data)
    {
        if (data == null) return;
        _sMercenary = data;
        _uiData = new MergedUIData(_mercenaryData, _sMercenary[0], Common.ePage.eTeam);
        NotifyObservers(_uiData);
    }

    IObserver<ISlotExhibition> _observer;
    public void ResistObserver(IObserver<ISlotExhibition> observer)
    {
        _observer = observer;

        NotifyObservers(_uiData);
    }

    public void NotifyObservers(ISlotExhibition data)
    {
        _observer.Set(data);
    }



}
