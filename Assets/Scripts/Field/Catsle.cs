using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catsle : Singleton<Catsle>
{
    [SerializeField]
    short HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 15;
        transform.position = StageLoader.Instance.CurrentMapInfo._castlePoint;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("클리어 실패");
        HP--;
        if (HP<=0)
        {
            Debug.Log("클리어 실패");
        }
    }

}
