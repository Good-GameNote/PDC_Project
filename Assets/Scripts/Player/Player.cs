using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;


public struct Cash
{
    long _limiteAt;
    long _buyAt;
};

public struct Asset
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMoney.MAX_MONEY_SIZE)]
    int[] _money;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eCash.MAX_CASH_SIZE)]
    Cash[] _cash;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eTime.MAX_TIME_SIZE)]
    long[] _time;
};

struct SP_LoadPlayer
{
    public SP_LoadPlayer(byte i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadPlayer;
        asset = new Asset();
    }
    public short _size;
    public short _index;
    public Asset asset;
};


public class Player : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SP_LoadPlayer>((int)ePacket.eSP_LoadPlayer, (p) =>
        {
            Debug.Log(p.asset);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
