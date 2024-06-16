
public interface ICanExhibition
{
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

/// <summary>
/// 용병 및 유물 슬롯
/// </summary>
public interface ISlotExhibition : ICanExhibition
{
    int GiveLevel();
}
