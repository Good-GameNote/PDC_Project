using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Common;

public class FireArrowMercenary : Mercenary
{
    [SerializeField]
    private ProjectileBase _fireArrowPrefab;

    public static eEffector[] curseNums = new eEffector[] { eEffector.e돋보기 };

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
