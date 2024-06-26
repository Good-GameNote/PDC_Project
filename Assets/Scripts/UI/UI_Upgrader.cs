using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common;

public class UI_Upgrader : Singleton<UI_Upgrader>
{
    [SerializeField]
    ePage type;
  
        public void Upgrade(int index)
    {
        CP_Upgrade packet = new CP_Upgrade(0);
        packet._type = (short)type;
        packet._purchasIndex = (short)index;
        GameManager.Instance._packetManager.Send(packet, packet._size);
    }
}
