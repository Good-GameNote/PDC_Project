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
    public Splash Splash 
    { 
        get ; 
        set ; 
    }
    protected IMission _mission;
    protected Mercenary _owner;
    protected Transform _targetTransform;

    protected List<Enemy> _findingTargets = new List<Enemy>();

    protected List<Debuff> _debuffList = new List<Debuff>();

    public abstract void Move();

    public void Initialize( Transform targetTransform, Mercenary owner)
    {
        _targetTransform = targetTransform;
        _owner = owner;
        _damage = _owner._mercenaryData.Damage.Value;

    }

    private void Update() 
    {
        if(_targetTransform == null) return;

        Move();
    }

    private void OnEnable() 
    {
        if(_owner == null) transform.parent.TryGetComponent(out _owner);
    }
}
