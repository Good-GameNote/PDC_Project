

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


    public enum All_ERROR
    {
        success,
        lackMoney,
        lackLevel,
        duplication,
        slang,
        tooLong,
        tooMany,
        notExist,
    };



    public enum ePacket
    {
        eCP_Test,
        eSP_Test,
        eCP_Enter,
        eCP_Nick,
        eSP_Nick,
        eSP_LoadPlayer,
        eSP_LoadMercenarys,
        eSP_LoadTown,
        eSP_LoadInventory,
        eSP_LoadStages,
        MAX_FUNC_SIZE
    };
    #endregion

    #region struct



    #endregion
}
