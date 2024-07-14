using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common;

public class FireArrowMercenary : Mercenary
{
    static eEffector[][] _characteristic= new eEffector[][]
    {
    new eEffector[] { eEffector.e갈래화살,eEffector.e갈래화살},
    new eEffector[] { eEffector.e갈래화살 },
    new eEffector[] { eEffector.e갈래화살 }
    };

    [SerializeField]
    private ProjectileBase _fireArrowPrefab;



    public override eEffector[] CanStarUp()
    {
        if (_countByStar[_mercenaryData.Index][_star].Count<3|| _star>=3)
        {
            return null;
        }

        return _characteristic[_star];
    }

    void Start()
    {
        
    }

    public override void Attack()
    {
        if(_mercenaryAI._enemiesList.Count <= 0) return;
        // _mercenaryAI._enemiesList[0] == null
//Instantiate(_fireArrowPrefab, transform);
        ProjectileBase arrowGO = ProjectilePool.Instance.Get( _mercenaryData.Index ,  transform.position);
        arrowGO.Initialize(_mercenaryData.Damage, _mercenaryAI._enemiesList[0]);
    }

}
