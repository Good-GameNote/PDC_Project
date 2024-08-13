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
    private void Awake()
    {
        Splash = new NonSplash();
    }
    public override void Move()
    {
        Vector3 tr = _targetTransform.position - transform.position;
        tr.Normalize();
        transform.Translate(_movement * Time.deltaTime * tr, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent(out Enemy hit);
        if (hit == null) return;
        _findingTargets.Clear();
        _debuffList.Clear();
        //Slow a =  DebuffPool.Instance.Get((int)Common.eDebuff.eSlow, Vector3.zero) as Slow;
        //a.Init(30f, 0f, 2f);
        // Splash.Excute(hit, _mercenary, _damage, new List<Debuff>());
        Splash.FindTargets(hit, _findingTargets);

        for (int i = 0; i < _findingTargets.Count; i++)
        {
            if(_findingTargets[i]==null) continue;

            _findingTargets[i].TakeHit(_owner,_damage,_debuffList );
        

        }
        ProjectilePool.Instance.Release(this, (int)Common.eMercenary.eFireArrow);
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
