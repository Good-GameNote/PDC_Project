using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Debuff 
{
    Sprite _Sprite;

    float _durationTime;
    float _remainDuration;

    float _eleapse=.2f;
    float _lapseEleampse;
    
    public void SetDuration(float duration) {  _durationTime = duration; }

    Enemy target;
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
            target.RemoveBuff(this);
        }
    }
}
