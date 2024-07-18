using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Card_Rew : UI_Card
{

    public override void CardAction()
    {
        _notify((short)transform.GetSiblingIndex());
    }
}
