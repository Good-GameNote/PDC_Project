using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Mercenary : MonoBehaviour,IClickable
{
    [SerializeField]
    public MercenaryData _mercenaryData;

    sMercenary _sMercenary;

    ProjectileBase _projectile;
    protected MercenaryAI _mercenaryAI;


    static protected List<Mercenary>[][] _countByStar = new List<Mercenary>[(int)Common.eMercenary.MAX_MERCENARY_SIZE][]
    {
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
    };

    private void Awake() 
    {
        _mercenaryAI = GetComponentInChildren<MercenaryAI>();
        _mercenaryAI.SetCanSee(_mercenaryData);
        _mercenaryAI.SetRange(_mercenaryData.Range);
    }


    static protected int[] _magnificationByStar= new int[Common.MAX_STAR];

    protected short _star;
    private void OnEnable() 
    {
        StartCoroutine(SetCooltime());
        _countByStar[_mercenaryData.Index][_star].Add(this);
    }




    private void OnDisable()
    {
        _countByStar[_mercenaryData.Index][_star].Remove(this);

    }

    AttackEffect _attackEffect = new BaseAttack();

    public void UpStarGrade(out AttackEffect deco)
    { 
        deco = _attackEffect;
        _countByStar[_mercenaryData.Index][_star].Remove(this);
        for(int i =0; i<2; i++)
        {
            Mercenary offering = _countByStar[_mercenaryData.Index][_star][0];
            _countByStar[_mercenaryData.Index][_star].Remove(offering);

            MercenaryPool.Instance.Release(offering, _mercenaryData.Index);

        }


        _star++;
        _countByStar[_mercenaryData.Index][_star].Add(this);
    }
    public void Sell()
    {

        _countByStar[_mercenaryData.Index][_star].Remove(this);
        MercenaryPool.Instance.Release(this, _mercenaryData.Index);
    }

    public abstract ICardExhibition[] CanStarUp();
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

            _remainTime -= Time.deltaTime;
            if (_mercenaryAI._enemiesList.Count <= 0) yield return null;

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
