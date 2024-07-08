using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrowMercenary : Mercenary
{
    [SerializeField]
    private GameObject _fireArrowPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public override void Attack()
    {
        GameObject ArrowGO = Instantiate(_fireArrowPrefab, transform);
    }
}
