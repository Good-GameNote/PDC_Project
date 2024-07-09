using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff
{
    protected Sprite _sprite;

    protected float _durationTime;
    protected float _remainDuration;

    protected float _eleapse=.2f;
    protected float _lapseEleampse;

    public Debuff(float durationTime, Sprite sprite)
    {
        _remainDuration= _durationTime = durationTime;
       // SetDuration(_durationTime);
        _sprite = sprite;
    }

 
    //public void SetDuration(float duration) {  _remainDuration = duration; }

    protected Enemy _target;
    public  abstract void StartAction(Enemy target);

    public abstract void ContinueAction(float lapse);
    public abstract void EndAction();


    public void Activation()
    {
        if (_remainDuration > 0)
        {
            _remainDuration -= Time.deltaTime;

            _lapseEleampse += Time.deltaTime;
            if (_lapseEleampse>=_eleapse)
            {
                ContinueAction(_lapseEleampse);
                _lapseEleampse-= _eleapse;
            }
        }
        else
        {
            _target.RemoveBuff(this);
        }
    }
}
