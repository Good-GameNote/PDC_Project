
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;

public struct sRelic:IServerData
{
    public short index;
    public short level;
    public short surplus;

    public short GiveIndex()
    {
        return index;
    }
    public short GiveLevel()
    {
        return level;
    }

    public short GiveSurplus()
    {
        return surplus;
    }
};
struct SP_LoadInventory
{
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eRelic.MAX_RELIC_SIZE)]
    public sRelic[] relics;
};


public class Inventory : MonoBehaviour, IIndexableSubject<IServerData>
{
    sRelic[] _relics;

    private void Awake()
    {
        _relics = new sRelic[(int)eRelic.MAX_RELIC_SIZE];
        observers = new IObserver<IServerData>[(int)eRelic.MAX_RELIC_SIZE];

        GameManager.Instance._packetManager.Recieve<SP_LoadInventory>((int)eSPacket.eSP_LoadInventory, (p) =>
        {
            _relics = p.relics;
            foreach (var relic in _relics)
            {
                Debug.Log($"relic index ={relic.index}, level= {relic.level}, surplus ={relic.surplus}");
            }
        });
    }

    public void GachaResult(SP_Gacha sp)
    {
        _relics[sp._puchasindex].surplus++;

        if(_relics[sp._puchasindex].level==0)
        {
            Debug.Log("해금, 레벨업 함수 호출");
            SP_Upgrade usp = new SP_Upgrade();
            usp._puchasIndex = sp._puchasindex;
            UpgradeResult(usp);
        }
        NotifyObservers(sp._puchasindex);
    }
    public void Gach()
    {
        CP_Gacha packet = new CP_Gacha(0);
        packet._type = (short)ePage.eInven;
        packet._advanced = 0;
        GameManager.Instance._packetManager.Send(packet, packet._size);
    }
    IObserver<IServerData>[] observers;
    public void ResistObserver(short index, IObserver<IServerData> observer)
    {
        observers[index] = observer;
    }

    public void NotifyObservers(short index)
    {
        observers[index].Set(_relics[index]);
    }
    public void UpgradeResult(SP_Upgrade sp)
    {
        _relics[sp._puchasIndex].level++;
        NotifyObservers(sp._puchasIndex);
    }

}