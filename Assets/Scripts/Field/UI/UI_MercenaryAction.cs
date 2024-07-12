using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI_MercenaryAction : Singleton<UI_MercenaryAction>
{
    // Start is called before the first frame update
    [SerializeField]
    RectTransform rect;
    private void Start()
    {
    }

    Mercenary _sellected;
    public void TakeInfo(Mercenary sellected, Vector3 position)
    {        
        gameObject.SetActive (true);
        rect.position = position;
        _sellected = sellected;

    }

}
