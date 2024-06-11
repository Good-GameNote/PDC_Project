using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.VersionControl;
using UnityEngine;
using static Common;


public struct Cash
{
    long _limiteAt;
    long _buyAt;
};

public struct sAsset
{
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMoney.MAX_MONEY_SIZE)]
   public  int[] _money;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eCash.MAX_CASH_SIZE)]
    public Cash[] _cash;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eTime.MAX_TIME_SIZE)]
    public long[] _time;
};

struct SP_LoadPlayer
{
    public SP_LoadPlayer(byte i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadPlayer;
        asset = new sAsset();
    }
    public short _size;
    public short _index;
    public sAsset asset;
};


struct CP_RecordMoney
{
    public CP_RecordMoney(byte i)
    {
        _size = 12;
        _index = (short)ePacket.eCP_RecordMoney;
        moneyType = -1;
        value = -1;
        reason = -1;
    }
    public short _size;
    public short _index;

    public short moneyType;
    public short reason;
    public int value;
};


public class Player : MonoBehaviour
{
    sAsset _sAsset;

    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SP_LoadPlayer>((int)ePacket.eSP_LoadPlayer, (p) =>
        {
            _sAsset = p.asset;
            Debug.Log(p.asset);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        _sAsset = new sAsset();
    }

    public void Test()
    {
        ChangeMoney(eMoney.eDiamond, -500,eBuy.eRelicGacha);
    }
    public bool ChangeMoney(eMoney type, int value , eBuy reason)
    {
        if (value<0 && _sAsset._money[(int)type] < -value)
            return false;

        _sAsset._money[(int)type] += value;

        CP_RecordMoney cpRecord = new CP_RecordMoney(0);
        cpRecord.moneyType = (short)6;
        cpRecord.value = value;
        cpRecord.reason = (short)reason;
        GameManager.Instance.packetManager.Send(cpRecord, cpRecord._size);
        return true;
    }

}