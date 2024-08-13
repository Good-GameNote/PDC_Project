
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour,IIsDetacted
{
    [field: SerializeField]
    public EnemyData _enemyData {  get; private set; }
    public int _HP { get; private set; }
    public float _speed { get; private set; }

    short[] _states;
    static int eEnemyStateLength = Enum.GetValues(typeof(Common.eEnemyState)).Length;


    //[SerializeField]
    //NavMeshAgent _agent;
    [SerializeField]
    SpriteRenderer _renderer ;

    CurseEffect _curseDeco;

    Vector3 _destPoint;

    public bool IsDetacted(Common.eEnemyState state )
    {
        bool result=true;
        for (int i = 0; i < eEnemyStateLength; i++)
        {
            if ((state & (Common.eEnemyState)(1 << i)) == 0)
            {//용병이 이부분 못봄
                if (_states[i] > 0)//적이 이부분 가지고 있음
                {
                    result = false;//감지 못함
                    break;
                }
            }
        }
        return result;
    }
    private void Awake()
    {
        _HP = _enemyData.HP; 
        _speed = _enemyData.Speed;

        _renderer.sprite = _enemyData.Sprite;
        _states = new short[eEnemyStateLength];

        ChangeState(_enemyData.ShowTypes, 1);

        //_agent = GetComponent<NavMeshAgent>();
        //_agent.updateRotation = false;
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

    public void ChangeState(Common.eEnemyState state, sbyte change)//1 or -1
    {
        for (int i = 0; i < eEnemyStateLength; i++)
        {
            if ((state & (Common.eEnemyState)(1 << i)) != 0)
            {
                _states[i]+= change;
            }
        }
    }

    public void SetInitPosition()
    {
       // _agent.Warp(Field.Instance._enemySpot.position);
    }
    private void OnEnable()
    {
        transform.position=Catsle.Instance.transform.position;
        
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

    public void TakeDest(Vector3 dest)
    {
        _destPoint = dest;
    }
    private void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position, _destPoint, _speed);
    }
}
