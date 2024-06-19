

using System.Net.Sockets;
using System;
using Unity.VisualScripting;
using System.Runtime.InteropServices;

public class Common
{

    public const int MAX_PACKET_SIZE = 1024;
    public const int MAX_NICKNAME_SIZE = 10;//닉네임 최대 글자수
    public const int TOKEN_SIZE = 20;

    public const int MAX_STAGE_SIZE = 100;


    public static readonly int screenWide = 360;
    public static readonly int screenHeight = 640;



    #region enum
    public enum eRelic
    {
        eA,
        eB,
        MAX_RELIC_SIZE
    };

    public enum eBuilding
    {
        eAlchemyWorkshop,
        eMine,
        eAdventurerGuild,
        eArena,
        MAX_BUILDING_SIZE
    };

    public enum eMercenary
    {
        eFireArrow,
        eFireGhostRider,
        MAX_MERCENARY_SIZE
    };


    public enum eMoney
    {
        eGold,
        eDiamond,
        eRock,
        eRubi,
        eEnerge,
        MAX_MONEY_SIZE
    };

    public enum eCash
    {
        eAds,
        MAX_CASH_SIZE
    };


    public enum eTime
    {
        eSiege,
        eAd,
        eLogin,
        eLogout,
        eNickChange,
        MAX_TIME_SIZE
    };


  
    public enum eBuy
    {
        eRelicGacha,
        eRelicAdvancedGacha,
        eMercenaryUp,
        eTowerUp,
        MAX_BUY_SIZE
    };

    public enum eEffector
    {
        eA, //머시기하는 이펙트
        eB,
        eC, 
        eD,
        MAX_EFFECTOR_SIZE
    }
    public enum ePage
    {
        eShop,
        eTeam,
        eStage,
        eInven,
        eTown,
        MAX_Page_SIZE
    };

    public enum All_ERROR
    {
        eSuccess,
        eLackMoney,
        eLackLevel,
        eDuplication,
        eSlang,
        eTooLong,
        eTooMany,
        eNotExist,
    };


    public enum eCPacket
    {
        eCP_Test,
        eCP_Enter,
        eCP_Nick,
        eCP_RecordMoney,
        MAX_CPACKET_SIZE
    };

    public enum eSPacket
    {
        eSP_Test,
        eSP_Nick,
        eSP_LoadPlayer,
        eSP_LoadMercenarys,
        eSP_LoadTown,
        eSP_LoadInventory,
        eSP_LoadStages,
        MAX_SPACKET_SIZE
    };


    #endregion

    #region struct
    public struct CP_Enter
    {
        public CP_Enter(byte i)
        {
            _size = 24;
            _index = (short)eCPacket.eCP_Enter;
            _token = new byte[TOKEN_SIZE];
        }

        public short _size;
        public short _index;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SIZE)]
        public byte[] _token;
    };


    #endregion
}
