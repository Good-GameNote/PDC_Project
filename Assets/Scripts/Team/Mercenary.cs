using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mercenary : MonoBehaviour
{
    [SerializeField]
    protected MercenaryData _mercenaryData;

    sMercenary _sMercenary;

    IAttackDecorator _attackDecorator;

    ProjectileBase _projectile;
    protected MercenaryAI _mercenaryAI;
    

    private void Awake() 
    {
        _mercenaryAI = GetComponentInChildren<MercenaryAI>();
        _mercenaryAI.SetCanSee(_mercenaryData);
        _mercenaryAI.SetRange(_mercenaryData.Range);
    }
    private void OnEnable() 
    {
        StartCoroutine(SetCooltime());
    }

    public void SetsMercenary(sMercenary sMercenary)
    {
        _sMercenary = sMercenary;
    }

    public void LostTarget()
    {
        // _myTarget = _mercenaryAI._enemiesList[0];
    }

    IEnumerator SetCooltime()
    {
        float _remainTime = _mercenaryData.CoolTime;
         Attack();
        while(true)
        {
            if(_mercenaryAI._enemiesList.Count <= 0) yield return null;

            _remainTime -= Time.deltaTime;
            if(_remainTime <= 0)
            {
                Attack();
                _remainTime = _mercenaryData.CoolTime;
            }
            yield return null;
        }
    }

    public virtual void Attack()
    {
    }
}
