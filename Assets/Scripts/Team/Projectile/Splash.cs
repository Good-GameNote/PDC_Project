using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Splash : Component
{
    public float SplashRange { get; protected set; }
    public Sprite EffectSprite { get; protected set; }
    public float EffectDuration { get; protected set; }

    public Splash(float splashRange, float effectDuration, Sprite effectSprite = null)
    {
        SplashRange = splashRange;
        EffectDuration = effectDuration;
        EffectSprite = effectSprite;
    }

    public abstract void Excute(IGetHit getHit, Mercenary mercenary, int damage, Debuff debuff);
}

public class NonSplash : Splash
{
    public NonSplash() : base(0f, 0f)
    {
    }

    public override void Excute(IGetHit getHit, Mercenary mercenary, int damage, Debuff debuff)
    {
        Debug.Log($"CC");
        getHit.GetHit(mercenary, damage, debuff);
    }
}

public class CircleSplash : Splash
{
    Collider[] _enemyColliders = new Collider[10];
    IGetHit _getHit;
    public CircleSplash(float splashRange, float effectDuration) : base (splashRange, effectDuration)
    {
    }

    public override void Excute(IGetHit getHit, Mercenary mercenary, int damage, Debuff debuff)
    {
        Debug.Log($"DD");
        _enemyColliders = Physics.OverlapSphere(transform.position, SplashRange, LayerMask.NameToLayer("Monster"));
        foreach (var enemy in _enemyColliders)
        {
            if(enemy != null)
            {
                TryGetComponent(out _getHit);
                _getHit.GetHit(mercenary, damage, debuff);
            }
        }
    }
}