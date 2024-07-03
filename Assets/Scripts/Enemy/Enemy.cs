
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [field: SerializeField]
    public EnemyData _enemyData {  get; private set; }

    ICurseDecorator _curseDeco;

    public int _HP { get; private set; }

    public float _speed { get; private set; }



    List<Debuff> _debuffs = new();

    short[] _states;
    private void Awake()
    {
        _HP = _enemyData.HP; 
        _speed = _enemyData.Speed;
        _states = new short[(int)Common.eEnemyState.MAX_ENEMY_STATE_SIZE];
        _states[(int)Common.eEnemyState.eAir] = _enemyData.IsAir;
        _states[(int)Common.eEnemyState.eHide] = _enemyData.IsHide;

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

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
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
