using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenaryPool : ObjectPool<Mercenary>
{

    private void Awake()
    {
        Init(_prefabs);
    }
}
