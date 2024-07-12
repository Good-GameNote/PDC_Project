﻿

public class Common
{

    public const int MAX_PACKET_SIZE = 1024;
    public const int MAX_NICKNAME_SIZE = 10;//닉네임 최대 글자수
    public const int TOKEN_SIZE = 20;

    public const int MAX_STAGE_SIZE = 100;

    public const int ENCRYPTED_SIZE = 32;

    public static readonly int screenWide = 360;
    public static readonly int screenHeight = 640;

    public const float MERCENARY_SIZE = 0.35f;


    #region enum

    public enum eLayer
    {
        Default = 0,
        TransparentFX = 1,
        IgnoreRaycast = 2,
        Obstacle = 3,
        Water = 4,
        UI = 5,
        EnemyPath = 6,
        Enemy = 7,
        Mercenary = 8,
        Ground = 9,
    }
    public enum eRelic
    {
        e돋보기,
        eRelicB,
        eRelicC,
        eRelicD,
        eRelicE,
        eRelicF,
        eRelicG,
        eRelicH,
        eRelicI,
        eRelicJ,
        eRelicK,
        eRelicL,

        MAX_RELIC_SIZE
    };

    public enum eEnemyState
    {
        eStun,
        eAir,
        eHide,
        MAX_ENEMY_STATE_SIZE
    }

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
    public enum eOption
    {
        eUsingDeck,
        eSellectStage,
        MAX_Option_SIZE
    };

    public enum eCanI
    {
        eEnterBattle,
        MAX_Page_SIZE
    };


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
        eLackCost,
        eLackSlot,
        eOverMaxLevel,
        eLackCard,
        eLackEnergy,
    };


    public enum eEffector
    {
        e돋보기, // 3->6->9미만대미지 증폭
        eB,
        eC,
        eD,
        e갈래화살,
        MAX_EFFECTOR_SIZE
    }

    public enum eCPacket
    {
        eCP_Test,
        eCP_Enter,
        eCP_Nick,
        eCP_Gacha,
        eCP_Upgrade,
        eCP_RegistRelic,
        eCP_ChangeDeck,
        eCP_StageProcess,
        eCP_CanI,
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
        eSP_Gacha,
        eSP_Upgrade,
        eSP_RecordMoney,
        eSP_CanI,
        MAX_SPACKET_SIZE
    };


    #endregion

}
