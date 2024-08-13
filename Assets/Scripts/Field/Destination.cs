using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Destination : MonoBehaviour
{
    Destination next;
    Enemy enemy;
    LayerMask _destLayer = 1 << (int)Common.eLayer.Dest;
    static Vector3[] directions= {Vector3.left,Vector3.right,Vector3.forward,Vector3.back};
    public void SetChain(Destination prev=null)
    {
        for (int i = 0; i < directions.Length; i++)
        {
            if (Physics.Raycast(transform.position, directions[i], out RaycastHit hitInfo, 100, _destLayer))
            {
                hitInfo.transform.TryGetComponent(out next);
                if (next&& next!= prev)
                {
                    next.SetChain(this);
                    break;
                }
            }
        }
        if (next!=null)
        {

            Catsle.Instance.Init(transform);
        }
    }


private void OnTriggerEnter(Collider other)
    {
        if (!next) return;
        other.TryGetComponent(out enemy);
        if( enemy)
        {
            enemy.TakeDest(next.transform.position);
        }
    }
}
