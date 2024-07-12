using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Mercenary : MonoBehaviour,IClickable
{
    [SerializeField]
    public MercenaryData _mercenaryData;

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

    protected short _star;

    static protected List<Mercenary>[][] _countByStar = new List<Mercenary>[(int)Common.eMercenary.MAX_MERCENARY_SIZE][];
    private void OnEnable() 
    {
        StartCoroutine(SetCooltime());
        _countByStar[_mercenaryData.Index][_star].Add(this);
    }

    static protected int[] _magnificationByStar= new int[4];



    private void OnDisable()
    {
        _countByStar[_mercenaryData.Index][_star].Remove(this);

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


    public void OnBeginDrag(Vector3 hit)
    {
        Debug.Log($"111 {hit}");
        UI_MercenaryAction.Instance.TakeInfo(this,  Vector3.up*40+ Input.mousePosition);
    }

    public void OnDrag(Vector3 hit)
    {
        Debug.Log($"222 {hit}");

    }

    public void OnEndDrag(Vector3 hit)
    {
        Debug.Log($"%%% {hit}");

    }
}
