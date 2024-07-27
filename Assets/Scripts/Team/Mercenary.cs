using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Mercenary : MonoBehaviour,IClickable, IObserver<sMercenary[]>, ISlotExhibition,ISubject<ISlotExhibition>
{
    [SerializeField]
    public MercenaryData _mercenaryData;

    sMercenary[] _sMercenary;

    ProjectileBase _projectile;
    protected MercenaryAI _mercenaryAI;


    static protected List<Mercenary>[][] _countByStar = new List<Mercenary>[(int)Common.eMercenary.MAX_MERCENARY_SIZE][]
    {
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
        new List<Mercenary>[Common.MAX_STAR] { new (), new (),new (),new() },
    };

    private void Awake() 
    {
        GameManager.Instance._team.ResistObserver((short)_mercenaryData.Index, this);
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

    IObserver<ISlotExhibition> _observer;
    public void ResistObserver(IObserver<ISlotExhibition> observer)
    {
        _observer = observer;
    }

    public void NotifyObservers(ISlotExhibition data)
    {
        _observer.Set(this);
    }

    public void Set(sMercenary[] data)
    {
        _sMercenary = data;
    }

    public Common.ePage GiveType()
    {
        throw new System.NotImplementedException();
    }

    public short GiveIndex()
    {
        throw new System.NotImplementedException();
    }

    public Sprite GiveSprite()
    {
        throw new System.NotImplementedException();
    }

    public string GiveName()
    {
        throw new System.NotImplementedException();
    }

    public short GiveLevel()
    {
        throw new System.NotImplementedException();
    }

    public short GiveSurplus()
    {
        throw new System.NotImplementedException();
    }
}
