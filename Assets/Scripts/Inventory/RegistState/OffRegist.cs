




class OffRegist :  RegistSate
{
    protected override bool  InChange(ref RegistSate self, Relic relic, bool sendPacket)
    {
        if (!sendPacket&&(relic._sRelic[0]._bitDeckNum & 1<<(GameManager.Instance._inven.CurDeckNum-1)) == 0)
        {
            return false;
        }

        Common.All_ERROR err = RelicResister.Instance.ResistRelic(relic , sendPacket);
        if (err != Common.All_ERROR.eSuccess)
        {
            Warning.Instance.Show(err);
            return false;
        }
        self = other;
        return true;
    }
}
