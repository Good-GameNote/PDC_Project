using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IClickable
{
    Mercenary _tower;

    public void TakeTower(Mercenary tower)
    {
        _tower = tower;

    }
    public void OnBeginDrag(Vector3 point)
    {
        if (_tower)
        {
            Debug.Log("타워상세 ui");
            
        }
        else
        {
            Debug.Log("타워목록 ui");
            
        }
    }

    public void OnDrag(Vector3 point)
    {
    }

    public void OnEndDrag(Vector3 point)
    {
    }
}
