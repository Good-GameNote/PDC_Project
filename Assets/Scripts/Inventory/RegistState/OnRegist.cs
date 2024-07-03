

using UnityEngine;
using static Common;

class OnRegist :  RegistSate
{

    protected override bool InChange(ref RegistSate self, Relic relic, bool sendPacket)
    {
        if (!sendPacket&&(relic._sRelic[0]._bitDeckNum & 1<< (GameManager.Instance._inven.CurDeckNum-1)) != 0)
        {
            return false;
        }
        RelicResister.Instance.DereRelic(relic);

        self = other;

        return true;
    }
}
