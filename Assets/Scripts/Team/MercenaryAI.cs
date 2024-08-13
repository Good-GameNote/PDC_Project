using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MercenaryAI : MonoBehaviour
{
    public LayerMask layerMask;
    public List<Transform> _enemiesList = new();

    private float _range;
    private SphereCollider _perceptionCollider;
    IIsDetacted _isDetacted;
    Common.eEnemyState _canSee;

    private void OnEnable() 
    {
        if(_perceptionCollider == null)
        {
            bool isGetCollider = TryGetComponent(out _perceptionCollider);
            if(isGetCollider == false)
            {
                gameObject.AddComponent<SphereCollider>();
            }
            _perceptionCollider.GetComponent<SphereCollider>();
        }
        _perceptionCollider.isTrigger = true;
        _perceptionCollider.radius = _range;
    }

    void Update()
    {
        
    }

    public void SetCanSee(MercenaryData mercenaryData)
    {
        _canSee = mercenaryData.ThingCanSee;
    }

    void OnTriggerEnter(Collider other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            Transform enemyTransform = other.transform;
            enemyTransform.gameObject.TryGetComponent<IIsDetacted>(out _isDetacted);
            if(_isDetacted.IsDetacted(_canSee))
            {
                _enemiesList.Add(enemyTransform);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            Transform enemyTransform = other.transform;
            _enemiesList.Remove(enemyTransform);
        }
    }

    public List<Transform> GetEnemiesInRange()
    {
        return _enemiesList;
    }

    public void SetRange(float range)
    {
        _range = range;
        if(_perceptionCollider != null)
        {
            _perceptionCollider.radius = _range;
        }
    }
}
