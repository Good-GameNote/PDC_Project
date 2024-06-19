using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


using static Common;

public struct CP_Test
{
    public CP_Test(int dummy)
    {
        _size = 20;
        _index = (short)eCPacket.eCP_Test;
        _StringlVariable = new byte[16];
    }
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] _StringlVariable;
}


[Serializable]
public struct SP_Test
{
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
    public byte[] _StringlVariable;
}

public struct CP_Nick 
{
    public CP_Nick(byte i)   
    {
        _size = 24;
        _index = (short)eCPacket.eCP_Nick;
        _nickName = new byte[MAX_NICKNAME_SIZE*2];
    }

    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_NICKNAME_SIZE * 2)]
    public byte[] _nickName ;
};

public struct SP_Nick
{
    public short _size;
    public short _index;

    public short _result;//eNickCheck

}



//struct SP_LoadPlayer 
//{
//    public SP_LoadPlayer(byte i)
//    {
//        _size = 44;
//        _index = (short)ePacket.eSP_LoadPlayer;
//        asset = new Common.Asset();
//    }
//    public short _size;
//    public short _index;
//    public Common.Asset asset;
//};




//struct SP_LoadStages
//{
//    public SP_LoadStages(int i)  
//    {
//        _size = 44;
//        _index = (short)ePacket.eSP_LoadStages;
//        stages = new Stage[Common.MAX_STAGE_SIZE];
//    }
//    public short _size;
//    public short _index;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.MAX_STAGE_SIZE)]
//    public Stage[] stages;
//};

//struct SP_LoadMercenarys
//{
//    public SP_LoadMercenarys(int i)
//    {
//        _size = 44;
//        _index = (short)ePacket.eSP_LoadMercenarys;
//        mercenarys = new Mercenary[(int) eMercenary. MAX_MERCENARY_SIZE];
//    }
//    public short _size;
//    public short _index;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMercenary.MAX_MERCENARY_SIZE)]
//    public Mercenary[] mercenarys;
//};

//struct SP_LoadInventory
//{
//    public SP_LoadInventory(int i)
//    {
//        _size = 44;
//        _index = (short)ePacket.eSP_LoadInventory;
//        relics = new Common.Relic[(int)eRelic.MAX_RELIC_SIZE];
//    }
//    public short _size;
//    public short _index;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eRelic.MAX_RELIC_SIZE)]
//    public Relic[] relics;
//};



//struct SP_LoadTown
//{
//    public SP_LoadTown(int i)
//    {
//        _size = 44;
//        _index = (short)ePacket.eSP_LoadTown;
//        buildings = new Common.Building[(int)eBuilding.MAX_BUILDING_SIZE];
//    }
//    public short _size;
//    public short _index;
//    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eBuilding.MAX_BUILDING_SIZE)]
//    public Building[] buildings;
//};


public class JoinTest : MonoBehaviour
{


    [SerializeField]
    InputField tokenField;


    [SerializeField]
    InputField nickField;

    private void Awake()
    {
        GameManager.Instance._packetManager.Recieve<SP_Nick>((int)eSPacket.eSP_Nick, (p) =>
        {
            Debug.Log(p._result);
        });
    
        GameManager.Instance._packetManager.Recieve<SP_Test>((int)eSPacket.eSP_Test, (p) =>
        {
            Debug.Log(Encoding.Unicode.GetString(p._StringlVariable));
        });

        CP_Test _SendPacket = new CP_Test(0);
        Buffer.BlockCopy(Encoding.Unicode.GetBytes("클라"), 0, _SendPacket._StringlVariable, 0, 4);
        GameManager.Instance._packetManager.Send(_SendPacket, _SendPacket._size);


        //GameManager.Instance.packetManager.Recieve<SP_LoadPlayer>((int)ePacket.eSP_LoadPlayer, (p) =>
        //{
        //    Debug.Log(p.asset);
        //});
        //GameManager.Instance.packetManager.Recieve<SP_LoadStages>((int)ePacket.eSP_LoadStages, (p) =>
        //{
        //    Debug.Log(p.stages);
        //});
        //GameManager.Instance.packetManager.Recieve<SP_LoadMercenarys>((int)ePacket.eSP_LoadMercenarys, (p) =>
        //{
        //    Debug.Log(p.mercenarys);
        //});
        //GameManager.Instance.packetManager.Recieve<SP_LoadTown>((int)ePacket.eSP_LoadTown, (p) =>
        //{
        //    Debug.Log(p.buildings);
        //});
        //GameManager.Instance.packetManager.Recieve<SP_LoadInventory>((int)ePacket.eSP_LoadInventory, (p) =>
        //{
        //    Debug.Log(p.relics);
        //});

    }
    public void SendNickPacket()
    {
        CP_Nick packet = new CP_Nick(0);
        Buffer.BlockCopy(Encoding.Unicode.GetBytes(nickField.text), 0, packet._nickName, 0, nickField.text.Length*2);

        GameManager.Instance._packetManager.Send(packet, packet._size);
    }
    public void SendEnterPacket()
    {
        CP_Enter packet = new CP_Enter(0);
        Buffer.BlockCopy(Encoding.UTF8.GetBytes(tokenField.text), 0, packet._token, 0, tokenField.text.Length );

        GameManager.Instance._packetManager.Send(packet, packet._size);


    }
}
