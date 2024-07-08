
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour,IIsDetacted,IGetHit
{
    [field: SerializeField]
    public EnemyData _enemyData {  get; private set; }


    public int _HP { get; private set; }

    public float _speed { get; private set; }



    List<Debuff> _debuffs = new();

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
 
    public void GetHit( Mercenary attacker, int damage, Debuff debuff)
    {
        _curseDeco.GetHitEffect( this, attacker, damage, debuff);
    }


    public void GetDamage(int damage)
    {
        _HP -= damage;
        if (_HP < 0 )
        {
            _HP = 0;
        }
    }


    public void GetDebuff(Debuff debuff)
    {
        _debuffs.Add( debuff );
        debuff.StartAction(this);
    }
    public void RemoveBuff(Debuff target)
    {
        target.EndAction();
        _debuffs.Remove( target );
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
        _agent.Warp(StageLoader.Instance.CurrentMapInfo._enemySpot);
    }
    private void OnEnable()
    {

        _agent.SetDestination(Catsle.Instance.transform.position);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach ( Debuff debuff in _debuffs )
        {
            debuff.Activation();
        }

    }
}
