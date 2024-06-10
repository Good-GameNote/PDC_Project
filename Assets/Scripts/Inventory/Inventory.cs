using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;

public struct sRelic
{
    public short level;
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
    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SP_LoadInventory>((int)ePacket.eSP_LoadInventory, (p) =>
        {
            Debug.Log(p.relics);
        });
    }

}
