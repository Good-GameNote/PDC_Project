using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Relic: MonoBehaviour,IEffector,ICanExhibition
{
    
    public RelicData _relicData;

    private sRelic _sRelic; //0이면 해금안됨

    private List<IEffector> _effectors;

    private void Awake()
    {
    }
    public void SetsRelic(sRelic sRelic)
    {
        _sRelic = sRelic;
    }

    public Sprite GiveSprite()
    {
        return _relicData._sprite;
    }
    public string GiveName()
    {
        return _relicData._name;
    }
    public int GiveValue()
    {
        return _sRelic.level;
    }

    public void Operate(int level)
    {
        for(int i =0;i< _effectors.Count;i++)
        {
            _effectors[i].Operate(_sRelic.level);
        }
    }

    public string GiveExplan(int level)
    {
        List<string> dumystring= new List<string>();
        for (int i = 0; i < _effectors.Count; i++)
        {
            dumystring.Add(_effectors[i].GiveExplan(_sRelic.level));
        }
        return CombineStrings(dumystring);
    }
    static string CombineStrings(List<string> words)
    {
        if (words == null || words.Count == 0)
        {
            return string.Empty;
        }

        for (int i = 0; i < words.Count - 1; i++)
        {
            if (i!=words.Count-1 &&words[i].EndsWith("합니다"))
            {
                words[i] = words[i].Substring(0, words[i].Length - 3) + "하고,";
            }
        }

        // 마지막 배열엔 '.'을 추가합니다.
        words[words.Count - 1] += ".";

        // 배열을 하나의 문자열로 합칩니다.
        return string.Join(" ", words);
    }

    public float GetPriority()
    {
        return 0;
    }


}
