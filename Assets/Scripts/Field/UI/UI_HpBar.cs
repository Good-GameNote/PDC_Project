using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HpBar : MonoBehaviour
{
    static Vector3 _offset= new Vector3 (0,0,0.7f);
    Transform _targetTrf;
    [SerializeField]
    UnityEngine.UI.Slider _gage;

    [field: SerializeField]
    public Transform DebuffSlotTrf;
    public void Init(Transform trf)
    {
        _targetTrf = trf;
        _gage.value = 1;
        gameObject.SetActive(false);
    }

    public void Set(float data)
    {
         gameObject.SetActive(true);
        _gage.value = data;
    }

    private void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(_targetTrf.position + _offset);
    }

}
