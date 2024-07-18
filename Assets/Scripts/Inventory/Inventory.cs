
using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;

public struct sRelic:IServerData
{
    public short index;
    public short level;
    public short surplus;
    public short _bitDeckNum;

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
    public short curDeck;
};


public class Inventory : MonoBehaviour, IIndexableSubject<sRelic[]>
{
    sRelic[][] _relics;//값타입을 참조타입처럼 쓰기위해 그냥 배열이 아닌 2중배열로 수정함.

    short[] _levelUpPoint = { 1, 2, 4, 6, 8, 10 };
    public short CurDeckNum { get; private set; }


    private void Awake()
    {
        _relics = new sRelic[(int)eRelic.MAX_RELIC_SIZE][];
        for (int i = 0; i < (int)eRelic.MAX_RELIC_SIZE; i++)
        {
            _relics[i] = new sRelic[1];
        }
        observers = new IObserver<sRelic[]>[(int)eRelic.MAX_RELIC_SIZE];

        GameManager.Instance._packetManager.Recieve<SP_LoadInventory>((int)eSPacket.eSP_LoadInventory, (p) =>
        {
            for (int i = 0; i < (int)eRelic.MAX_RELIC_SIZE; i++)
            {
                _relics[i][0] = p.relics[i];
            }
            
            CurDeckNum = p.curDeck;            
        });

    }

    public void ChangeDeck(short deckNum)
    {
        CP_ChangeOption cp = new CP_ChangeOption(0);
        cp._type = (short)eOption.eUsingDeck;
        cp._deckNum = deckNum;
        GameManager.Instance._packetManager.Send(cp, cp._size);

        CurDeckNum = deckNum;

        for (short i = 0; i < (int)eRelic.MAX_RELIC_SIZE; i++)
        {
            NotifyObservers(i);
        }
        UI_ClickSlotMenu.Instance.ClickThis(Relic.CurrentRelic.transform, Relic.CurrentRelic);
    }

    public void GachaResult(SP_Gacha sp)
    {
        _relics[sp._puchasindex][0].surplus++;

        if (_relics[sp._puchasindex][0].level==0)
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
    IObserver<sRelic[]>[] observers;
    public void ResistObserver(short index, IObserver<sRelic[]> observer)
    {
        observers[index] = observer;

        NotifyObservers(index);
    }

    public void NotifyObservers(short index)
    {
        observers[index]?.Set(_relics[index]);
        
    }
    public void UpgradeResult(SP_Upgrade sp)
    {
        _relics[sp._puchasIndex][0].surplus -= _levelUpPoint[_relics[sp._puchasIndex][0].level];
        _relics[sp._puchasIndex][0].level++;
        if(_relics[sp._puchasIndex][0].level==1)
        {
            Debug.Log("새로운카드 획득");
        }
        NotifyObservers(sp._puchasIndex);

    }
    
}