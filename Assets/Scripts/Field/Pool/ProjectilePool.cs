using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : ObjectPool<ProjectileBase>
{

    private void Awake()
    {
        Init( _prefabs);

    }
}

