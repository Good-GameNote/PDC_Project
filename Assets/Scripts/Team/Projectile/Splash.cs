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

    public abstract void FindTargets(Enemy origin, List<Enemy> targets);
}

public class NonSplash : Splash
{
    public NonSplash() : base(0f, 0f)
    {
    }

    public override void FindTargets(Enemy origin, List<Enemy>targets)
    {
        targets.Add(origin);
    }
}

public class CircleSplash : Splash
{
    Collider[] _enemyColliders = new Collider[10];
    Enemy _target;
    public CircleSplash(float splashRange, float effectDuration) : base (splashRange, effectDuration)
    {
    }

    public override void FindTargets(Enemy origin, List<Enemy> targets)
    {
        Debug.Log($"DD");
        _enemyColliders = Physics.OverlapSphere(transform.position, SplashRange, 1<<(int)Common.eLayer.Enemy);
        foreach (var enemy in _enemyColliders)
        {
            if(enemy != null)
            {
                TryGetComponent(out _target);
                if(_target != null)
                {
                    targets.Add(_target); 
                }
            }
        }
    }
}