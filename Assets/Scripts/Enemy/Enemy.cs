
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IIsDetacted
{
    [field: SerializeField]
    public EnemyData _enemyData {  get; private set; }
    public int _HP { get; private set; }
    public float _speed { get; private set; }

    short[] _states;

    [SerializeField]
    NavMeshAgent _agent;
    [SerializeField]
    SpriteRenderer _renderer ;

    CurseEffect _curseDeco;

    public bool IsDetacted(Common.eEnemyState[] stats )
    {

        return true;
    }
    private void Awake()
    {
        _HP = _enemyData.HP; 
        _speed = _enemyData.Speed;
        _states = new short[(int)Common.eEnemyState.MAX_ENEMY_STATE_SIZE];
        _states[(int)Common.eEnemyState.eAir] = _enemyData.IsAir;
        _states[(int)Common.eEnemyState.eHide] = _enemyData.IsHide;
        _renderer.sprite = _enemyData.Sprite;
        
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _curseDeco = CurseDecoTemplate.GiveCurseEffector();

    }
 
    public void TakeHit( Mercenary attacker, int damage, List<Debuff> debuff)
    {
        _curseDeco.TakeHitEffect( this, attacker, damage, debuff);
    }

    UI_HpBar _hpBar;

    public void TakeDamage(int damage)
    {
        _HP -= damage;

        if (_HP < 0 )
        {
            _HP = 0;
        }

        _hpBar.Set((float)_HP / _enemyData.HP);
    }


    float _speedChangeRate;
    float _fixedSpeedChange;

    public void ChangeMoveSpeed(float speedChangeRate, float fixedSpeedChange)
    {
        _speedChangeRate += speedChangeRate;
        _fixedSpeedChange += fixedSpeedChange;


        float fixedSlowSpeed = _enemyData.Speed - _fixedSpeedChange;

        if ( fixedSlowSpeed < 50 )
        {
            fixedSlowSpeed = 50;
        }

         _speed = (100 / (100 + _speedChangeRate)) * fixedSlowSpeed;
    }

    public void ChangeState(Common.eEnemyState state, short change)//1 or -1
    {
        _states[(int)state] += change;
    }

    public void SetInitPosition()
    {
        _agent.Warp(Field.Instance._enemySpot.position);
    }
    private void OnEnable()
    {
        _agent.SetDestination(Catsle.Instance.transform.position);
        
        _hpBar = HpBarPool.Instance.Get(transform.position);
        _hpBar.Init(transform);
    }
    private void OnDisable()
    {
        HpBarPool.Instance.Release(_hpBar, 0);
    }
    
    public Transform GiveDebuffSlot()
    {
        return _hpBar.DebuffSlotTrf;
    }

}
