using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercenary : MonoBehaviour
{
    [SerializeField]
    MercenaryData _mercenaryData;

    sMercenary _sMercenary;

    IAttackDecorator _attackDecorator;

    ProjectileBase _projectile;

    private void Awake() 
    {
        
    }
    void Start()
    {
        
    }

    public void SetsMercenary(sMercenary sMercenary)
    {
        _sMercenary = sMercenary;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
