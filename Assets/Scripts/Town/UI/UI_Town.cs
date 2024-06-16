using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Town : MonoBehaviour,IObserver<Common.ePage>
{
    Common.ePage _page = Common.ePage.eTown;
    public void Set(Common.ePage data)
    {
        gameObject.SetActive(_page == data);        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

