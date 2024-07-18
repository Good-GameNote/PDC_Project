using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CardSellecter_Mer : UI_CardSellecter
{
 
    public override void Action(short idx)
    {
        UI_MercenaryAction.Instance.Choice(Effector.Effectors[idx]);
    }
}
