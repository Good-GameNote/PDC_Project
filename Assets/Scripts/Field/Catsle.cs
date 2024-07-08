using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catsle : Singleton<Catsle>
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StageLoader.Instance.CurrentMapInfo._castlePoint;

    }



}
