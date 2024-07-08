using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MercenaryAI : MonoBehaviour
{
    public LayerMask layerMask;
    public UnityEvent<Transform> OnEnemyEnterRange;
    public UnityEvent<Transform> OnEnemyExitRange;
    public List<Transform> _enemiesList = new();

    private float _range;
    private CircleCollider2D _perceptionCollider;

    private void OnEnable() 
    {
        if(_perceptionCollider == null)
        {
            bool isGetCollider = TryGetComponent<CircleCollider2D>(out _perceptionCollider);
            if(isGetCollider == false)
            {
                gameObject.AddComponent<CircleCollider2D>();
            }
            _perceptionCollider.GetComponent<CircleCollider2D>();
        }
        _perceptionCollider.isTrigger = true;
        _perceptionCollider.radius = _range;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            Transform enemyTransform = other.transform;
            _enemiesList.Add(enemyTransform);
            OnEnemyEnterRange?.Invoke(enemyTransform);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((layerMask & (1 << other.gameObject.layer)) != 0)
        {
            Transform enemyTransform = other.transform;
            _enemiesList.Remove(enemyTransform);
            OnEnemyExitRange?.Invoke(enemyTransform);
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
