using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff:MonoBehaviour
{
    #region
    [SerializeField]
    protected UnityEngine.UI.Image _background;

    [SerializeField]
    protected UnityEngine.UI.Image _img;

    [SerializeField]
    protected Sprite _defaultSprite;

    protected float _durationTime;
    protected float _remainDuration;

    protected float _eleapse=.2f;
    protected float _lapseEleampse;

    protected virtual void Init(float durationTime, Sprite sprite)
    {
        gameObject.SetActive(false);
        _remainDuration= _durationTime = durationTime; 
        _img.sprite = sprite ?? _img.sprite;
    }
    protected abstract Common.eDebuff GiveType(); 

    protected Enemy _target;
    #endregion
    public void Excute(Enemy target)
    {
        _target = target;
        transform.SetParent(_target.GiveDebuffSlot()) ;
        StartAction();

        gameObject.SetActive(true);
    }
    protected  virtual void StartAction() { }
    protected virtual void ContinueAction(float lapse) { }
    protected virtual void EndAction() { }

    private void Update()
    {
        if(_target==null) return;

        if (_remainDuration > 0)
        {
            _remainDuration -= Time.deltaTime;

            _lapseEleampse += Time.deltaTime;
            if (_lapseEleampse >= _eleapse)
            {
                ContinueAction(_lapseEleampse);
                _lapseEleampse -= _eleapse;
            }
            _background.fillAmount = _remainDuration / _durationTime;
            _img.fillAmount = _remainDuration / _durationTime;
        }
        else
        {

            EndAction();
            DebuffPool.Instance.Release(this,(int)GiveType());
        }
    }

}
