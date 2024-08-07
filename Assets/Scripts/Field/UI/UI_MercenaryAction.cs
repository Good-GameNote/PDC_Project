using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MercenaryAction : Singleton<UI_MercenaryAction>
{
    // Start is called before the first frame update
    [SerializeField]
    RectTransform rect;

    [SerializeField]
    UnityEngine.UI.Button _upgradeButton;
    [SerializeField]
    UnityEngine.UI.Button _moveButton;
    [SerializeField]
    UnityEngine.UI.Button _sellButton;
    private void Awake()
    {
        _upgradeButton.onClick.AddListener(()=> { ViewMenu(); gameObject.SetActive(false); });

        EventTrigger trigger = _moveButton.gameObject.AddComponent<EventTrigger>();

        AddEventTrigger(trigger, EventTriggerType.PointerDown, (data) =>
        {
            Tongs.Instance.OnEmployeeSet(_sellected);
            Tongs.Instance.OnPointerDown((PointerEventData)data);
        });
        AddEventTrigger(trigger, EventTriggerType.Drag, (data) =>
        {
            Tongs.Instance.OnDrag((PointerEventData)data);
        });
        AddEventTrigger(trigger, EventTriggerType.PointerUp, (data) =>
        {
            Tongs.Instance.OnPointerUp((PointerEventData)data);
            gameObject.SetActive(false);
        });



        _sellButton.onClick.AddListener(() => { _sellected.Sell(); gameObject.SetActive(false); });

    }

    private void AddEventTrigger(EventTrigger trigger, EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener(action);
        trigger.triggers.Add(entry);
    }
    private void Start()
    {
    }
    [SerializeField]
    UI_CardSellecter _cardSellector;

    List< ICardExhibition> _list;
    Mercenary _sellected;
    public void TakeInfo(Mercenary sellected, Vector3 position)
    {        
        gameObject.SetActive (true);
        rect.position = position;
        _sellected = sellected;

        _list = _sellected.CanStarUp();

        _upgradeButton.gameObject.SetActive (_list != null);

    }

    public void ViewMenu()
    {
        _cardSellector.gameObject.SetActive (true);
        _cardSellector.SetCard(_list);
    }

    public void Choice(Effector effect)
    {
        effect.Choice(_sellected);

        _cardSellector.gameObject.SetActive(false);
        
    }


}
