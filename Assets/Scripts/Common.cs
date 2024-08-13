

using System;

public class Common
{

    static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        // Unix Epoch (1970년 1월 1일 00:00:00 UTC)
        return epoch.AddMilliseconds(unixTimeStamp).ToLocalTime();
    }

    public const int MAX_PACKET_SIZE = 1024;
    public const int MAX_NICKNAME_SIZE = 10;//닉네임 최대 글자수
    public const int TEST_SIZE = 48;

    public const int MAX_STAGE_SIZE = 100;

    public const int ENCRYPTED_SIZE = 32;

    public static readonly int screenWide = 360;
    public static readonly int screenHeight = 640;

    public const float MERCENARY_SIZE = 0.35f;

    public const int MAX_STAR = 4;

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
        Dest=10,
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

    [System.Flags]
    public enum eEnemyState
    {
        eStun=1<<0,
        eAir = 1 << 1,
        eHide = 1 << 2,
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
        eDummyMercenary1,
        eDummyMercenary2,
        eDummyMercenary3,
        eDummyMercenary4,
        MAX_MERCENARY_SIZE
    };


    public enum eMoney
    {
        eGold,
        eDiamond,
        eRock,
        eRubi,
        eEnerge,
        eAttendance,
        eLetter,
        eRecommend,
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
        MAX_OPTION_SIZE
    };

    public enum eCanI
    {
        eEnterBattle,
        MAX_CANI_SIZE
    };


    public enum ePage
    {
        eShop,
        eTeam,
        eStage,
        eInven,
        eTown,
        MAX_PAGE_SIZE
    };

    public enum eDebuff
    {
        eSlow,
        eStun,
        eBurn,
        MAX_DEBUFF_SIZE
    }

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

    public enum eBaseStat
    {
        eDamage,
        eAttackSpeed,
        eRange,
        eCritical,
        MAX_BASESTAT_SIZE
    }

    public enum eEffector
    {
        e돋보기, // 3->6->9미만대미지 증폭
        e인셉션,
        e10퍼추댐,
        e갈래화살,
        e화염묻히기,
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
        eCP_Contect,
        eCP_Reciept,
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
        eSP_LoadPosts,
        MAX_SPACKET_SIZE
    };


    #endregion

}
