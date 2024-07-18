using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

using System;
using static Common;


public class GameManager : Singleton<GameManager>
{


    void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        _packetManager.Recieve<SP_Gacha>((int)eSPacket.eSP_Gacha, (p) =>
        {
            if(p._result!= (short)All_ERROR.eSuccess)
            {
                Warning.Instance.Show((All_ERROR)p._result);
                return;
            }
            switch((ePage)p._type)
            {
                case ePage.eInven:
                    _inven.GachaResult(p);
                    break;
            }
        });

        _packetManager.Recieve<SP_Upgrade>((int)eSPacket.eSP_Upgrade, (p) =>
        {
            if (p._result != (short)All_ERROR.eSuccess)
            {
                Warning.Instance.Show((All_ERROR)p._result);
                return;
            }
            switch ((ePage)p._type)
            {
                case ePage.eInven:
                    _inven.UpgradeResult(p);
                    break;
            }

        });
        _packetManager.Recieve<SP_CanI>((int)eSPacket.eSP_CanI, (p) =>
        {
            if (p._result != (short)All_ERROR.eSuccess)
            {
                Warning.Instance.Show((All_ERROR)p._result);
                return;
            }
            switch ((eCanI)p._type)
            {
                case eCanI.eEnterBattle:
                     GotoBattle.Instance.Enter();
                    break;
            }

        });


    }
    private void Start()
    {
        
    }



    [field: SerializeField]
    public AddressableLoader _addressableLoader { get; private set; }

    [field:SerializeField]
    public PacketManager _packetManager { get; private set; }

    [field: SerializeField]
    public Player _player { get; private set; }
    [field: SerializeField]
    public Inventory _inven { get; private set; }
    [field: SerializeField]
    public Battle _battle { get; private set; }
    [field: SerializeField]
    public Team _team { get; private set; }
    [field: SerializeField]
    public Town _town { get; private set; }


    //[field: SerializeField]
    //public SceneLoader _sceneLoader { get; private set; }

}


public struct CP_Enter
{
    public CP_Enter(byte i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_Enter));
        _index = (short)eCPacket.eCP_Enter;
        _token = new byte[TOKEN_SIZE];
        _test = new byte[ENCRYPTED_SIZE];

    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SIZE)]
    public byte[] _token;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = ENCRYPTED_SIZE)]
    public byte[] _test;
};

public struct CP_Gacha
{
    public CP_Gacha(int i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_Gacha));
        _index = (short)eCPacket.eCP_Gacha;
        _type = 0;
        _advanced = 0;
    }
    public short _size;
    public short _index;

    public short _type;
    public short _advanced;
};
public struct SP_Gacha
{
    public short _size;
    public short _index;

    public short _result;
    public short _type;
    public short _puchasindex;
};

public struct CP_Upgrade
{
    public CP_Upgrade(int i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_Upgrade));
        _index = (short)eCPacket.eCP_Upgrade;
        _type = 0;
        _purchasIndex = 0;
    }
    public short _size;
    public short _index;

    public short _type;
    public short _purchasIndex;
};

public struct SP_Upgrade
{
    public short _size;
    public short _index;

    public short _result;
    public short _type;
    public short _puchasIndex;
};
public struct CP_ChangeOption//가벼운거 통보용
{
    public CP_ChangeOption(int i)
    {
        _size = (short)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CP_ChangeOption));
        _index = (short)Common.eCPacket.eCP_ChangeDeck;
        _type = 0;
        _deckNum = 1;
    }
    public short _size;
    public short _index;


    public short _type;
    public short _deckNum;
};
public struct CP_CanI 
{
    public CP_CanI(byte i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_CanI));
        _index = (short)eCPacket.eCP_CanI;
        _type = 0;
    }
    public short _size;
    public short _index;
    public short _type;
};

public struct SP_CanI
{
    public short _size;
    public short _index;

    public short _type;
    public short _result;
};

