using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public int _damage;
    // 투사체의 공격범위
    protected float _attackRange;
    // 투사체의 이동속도
    protected float _movement = 10.0f;
    // 투사체가 공중공격이 가능한지 여부
    protected bool _canAirAttack;
    // 투사체의 지속시간
    protected float _duration;
    // 투사체의 적 관통 수
    protected short _penetration;
    protected Splash _splash;
    public Splash Splash 
    { 
        get => _splash; 
        set => _splash = value; 
    }
    protected IMission _mission;
    protected Mercenary _mercenary;
    protected Transform _targetTransform;

    Mercenary orner;
    public abstract void Move();

    public void Initialize( Transform targetTransform, Mercenary orner)
    {
        _targetTransform = targetTransform;
    }

    private void Update() 
    {
        if(_targetTransform == null) return;

        Move();
    }
    public void SetSplash(Splash splash)
    {
        _splash = splash;
    }

    private void OnEnable() 
    {
        if(_mercenary == null) transform.parent.TryGetComponent(out _mercenary);
    }
}
