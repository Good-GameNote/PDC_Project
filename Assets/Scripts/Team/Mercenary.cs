using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mercenary : MonoBehaviour
{
    public enum MercenaryState
    {
        Create, Idle, Attack, Sell
    }
    [SerializeField]
    public MercenaryState _myState = MercenaryState.Create;

    [SerializeField]
    MercenaryData _mercenaryData;

    sMercenary _sMercenary;

    IAttackDecorator _attackDecorator;

    ProjectileBase _projectile;
    MercenaryAI _mercenaryAI;
    Transform _myTarget;

    private void Awake() 
    {
        _mercenaryAI = GetComponentInChildren<MercenaryAI>();
        _mercenaryAI.SetCanSee(_mercenaryData);
    }
    void Start()
    {
        
    }
    /// <summary>
    /// 용병의 상태변경시 해야하는 행동 나열
    /// </summary>
    /// <param name="state"></param>
    void ChangeState(MercenaryState state)
    {
        if(_myState == state) return;
        _myState = state;
        switch (_myState)
        {
            case MercenaryState.Create:
            break;
            case MercenaryState.Idle:
            break;
            case MercenaryState.Attack:
            break;
            case MercenaryState.Sell:
            break;
        }
    }

    /// <summary>
    /// 항시 감지되는 상태변경시 초기화해야하는 내용
    /// </summary>
    void StateProcess()
    {
        switch (_myState)
        {
            case MercenaryState.Create:
            ChangeState(MercenaryState.Idle);
            break;
            case MercenaryState.Idle:
            break;
            case MercenaryState.Attack:
            break;
            case MercenaryState.Sell:
            break;
        }
    }

    public void SetsMercenary(sMercenary sMercenary)
    {
        _sMercenary = sMercenary;
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }

    public void TargetInRange()
    {
        // _mercenaryAI.GetEnemiesInRange
    }

    public void LostTarget()
    {
        // _myTarget = _mercenaryAI._enemiesList[0];
    }

    public virtual void Attack()
    {
    }
}
