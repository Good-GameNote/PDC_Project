
using UnityEngine;

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

public class MergedUIData : ISlotExhibition
{
    ICanExhibition _scriptable;
    IServerData _sdata;
    Common.ePage _page;
    public MergedUIData(ICanExhibition scriptable, IServerData sdata, Common.ePage page )
    {
        _scriptable = scriptable;
        _sdata = sdata;
        _page = page;
    }
    public Common.ePage GiveType()
    {
        return _page;
    }

    public short GiveIndex()
    {
        return _scriptable.GiveIndex();
    }

    public Sprite GiveSprite()
    {
        return _scriptable.GiveSprite();
    }

    public string GiveName()
    {
        return _scriptable.GiveName();
    }

    public short GiveLevel()
    {
        return _sdata.GiveLevel();
    }

    public short GiveSurplus()
    {
        return _sdata.GiveSurplus();
    }


}

