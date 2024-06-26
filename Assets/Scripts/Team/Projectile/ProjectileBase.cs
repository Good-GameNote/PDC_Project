using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public int damage;
    // 투사체의 공격범위
    protected float _attackRange;
    // 투사체의 이동속도
    protected float _movement;
    // 투사체가 공중공격이 가능한지 여부
    protected bool _canAirAttack;
    // 투사체의 지속시간
    protected float _duration;
    // 투사체의 적 관통 수
    protected short _penetration;
    protected Splash _splash;
    protected Moving _moving;
    
    public abstract void Launch();
}
