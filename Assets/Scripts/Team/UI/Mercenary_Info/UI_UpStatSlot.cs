using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_UpStatSlot : MonoBehaviour
{

    [SerializeField]
    Text _explan;
    [SerializeField]
    Image _icon;
    [SerializeField]
    Text _liftingLevel;
    [SerializeField]
    Transform _liftingPanel;

    public void Set( UpStatData udata,int idx, int level  )
    {
        _icon.sprite = udata._stat.Icon;
        _explan.text = udata._explan;
        _liftingLevel.text = idx.ToString();
        if (idx+1 <= level)
        {
            _liftingPanel.gameObject.SetActive(true);
            udata.Excute(idx);
        }

    }


}
