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
    static Vector3[] directions= {Vector3.left,Vector3.right,Vector3.up,Vector3.down};
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
                    return;
                }
            }
        }
        if (prev )
        {

            Catsle.Instance.Init(transform);
        }
    }
    private void Update()
    {
        for (int i = 0; i < directions.Length; i++)
        {

            Debug.DrawRay(transform.position, directions[i] * 100, Color.red);
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
