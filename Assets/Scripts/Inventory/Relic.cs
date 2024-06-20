using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Relic: MonoBehaviour,ICanExhibition
{
    
    public RelicData _relicData;

    private sRelic _sRelic; //0이면 해금안됨

    private List<Effector> _effectors=new();

    private void Awake()
    {
        foreach (Common.eEffector effectNum in _relicData.EffectNums)
        {
            _effectors.Add(EffectorFactory.Create(effectNum));
        }
    }
    public void SetsRelic(sRelic sRelic)
    {
        _sRelic = sRelic;
    }

    public Sprite GiveSprite()
    {
        return _relicData.Sprite;
    }
    public string GiveName()
    {
        return _relicData.Name;
    }
    public int GiveValue()
    {
        return _sRelic.level;
    }


    public void Operate()
    {
        //for(int i =0;i< _effectors.Count;i++)
        //{
        //    _effectors[i].Operate();
        //}
    }

    public string GiveExplan()
    {
        List<string> dumystring= new List<string>();
        for (int i = 0; i < _effectors.Count; i++)
        {
            dumystring.Add(_effectors[i].GiveExplan());
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

}
