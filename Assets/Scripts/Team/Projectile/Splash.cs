using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash
{
    public float SplashRange { get; protected set; }
    public bool IsEnabled { get; protected set; }
    public Sprite EffectSprite { get; protected set; }
    public float EffectDuration { get; protected set; }

    public Splash(float splashRange, bool isEnabled, float effectDuration, Sprite effectSprite = null)
    {
        SplashRange = splashRange;
        IsEnabled = isEnabled;
        EffectDuration = effectDuration;
        EffectSprite = effectSprite;
    }
}

public class NonSplash : Splash
{
    public NonSplash() : base(0f, false, 0f)
    {
    }
}