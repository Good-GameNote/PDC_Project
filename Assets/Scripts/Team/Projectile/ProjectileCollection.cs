using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : ProjectileBase
{
    // [SerializeField]
    // private Sprite _fireArrowEffect;
    // [SerializeField]
    // private Sprite _fireArrowSplashEffect;

    // 무브
    public override void Move()
    {
        Vector3 tr = _targetTransform.position - transform.position;
        tr.Normalize();
        transform.Translate(_movement * Time.deltaTime * tr, Space.World);
        _splash = new NonSplash();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"AA");
        other.gameObject.TryGetComponent(out IGetHit hit);
        if(hit != null)
        {
            Debug.Log($"BB");
            Debuff a = new Slow(30f, 0f, 2f, default);
            _splash.Excute(hit, _mercenary, _damage, a);
        }
    }
}

// public class IceArrow : ProjectileBase
// {
//     [SerializeField]
//     private Sprite _iceArrowEffect;
//     [SerializeField]
//     private Sprite _iceArrowSplashEffect;

//     public override void Move()
//     {
//         throw new System.NotImplementedException();
//     }
// }
