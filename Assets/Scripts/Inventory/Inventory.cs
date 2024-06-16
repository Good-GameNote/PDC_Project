using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;

public struct sRelic
{
    public short index;
    public short level;
    public short surplus;
};
struct SP_LoadInventory
{
    public SP_LoadInventory(int i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadInventory;
        relics = new sRelic[(int)eRelic.MAX_RELIC_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eRelic.MAX_RELIC_SIZE)]
    public sRelic[] relics;
};

public class Inventory : MonoBehaviour
{
    Relic[] _relics;
    
    private void Awake()
    {
        _relics = new Relic[(int)eRelic.MAX_RELIC_SIZE];
        GameManager.Instance._packetManager.Recieve<SP_LoadInventory>((int)ePacket.eSP_LoadInventory, (p) =>
        {
            for(int i = 0;i <(int)eRelic.MAX_RELIC_SIZE;i++)
            {
                _relics[i].SetsRelic( p.relics[i]);
            }
            Debug.Log(p.relics);
        });
    }
    public void Gach()
    {

    }


}