using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrowMercenary : Mercenary
{

    public override List<ICardExhibition> CanStarUp()
    {
        if (_countByStar[_mercenaryData.Index][_star].Count<3|| _star>=3)
        {
            return null;
        }

        return _mercenaryData. _characteristic[_star];
    }

    void Start()
    {
        
    }


    

}
