using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject _relicBox;

    Relic[] _relics;

    public void Set(short level, short surplus)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    private void Awake()
    {
        _relics = _relicBox.GetComponentsInChildren<Relic>();
    }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
