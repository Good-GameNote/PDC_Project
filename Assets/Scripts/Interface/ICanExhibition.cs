
public interface ICanExhibition
{

    short GiveIndex();
    UnityEngine.Sprite GiveSprite();
    string GiveName();
}

/// <summary>
/// 보상 및 증강 선택지
/// </summary>
public interface ICardExhibition : ICanExhibition
{
    string GiveExplan(int level);
}

public interface IServerData
{
    short GiveLevel();
    short GiveSurplus();
}



/// <summary>
/// 용병 및 유물 슬롯
/// </summary>
public interface ISlotExhibition : ICanExhibition, IServerData
{
    Common.ePage GiveType();
}
