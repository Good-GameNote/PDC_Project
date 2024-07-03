using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Upgrader : MonoBehaviour, ISlotMenu
{

    [SerializeField]
    UnityEngine.UI.Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(() => { Upgrade(UI_ClickSlotMenu.Instance._purchas); });
        UI_ClickSlotMenu.Instance.Resist(this);
    }

    public void Show(ISlotExhibition purchas)
    {
        
    }

    public void Upgrade(ISlotExhibition data)
    {
        CP_Upgrade packet = new CP_Upgrade(0);
        packet._type = (short)data.GiveType();
        packet._purchasIndex = data.GiveIndex();
        GameManager.Instance._packetManager.Send(packet, packet._size);
    }
}
