using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Post : Singleton<UI_Post>, IObserver<List<SP_LoadPost>>
{

    [SerializeField]
    UI_PostSlot _slotPrefab;
    List<SP_LoadPost> _datas;

    [SerializeField]
    Transform _slotsParent;

    [SerializeField]
    UI_PostIn _postDetale;


    public void Set(List<SP_LoadPost> datas)
    {
        _datas = datas;
        for (int i=0; i< _datas.Count; i++)
        {
            UI_PostSlot slot =  Instantiate(_slotPrefab, _slotsParent);

            slot.SetContent(_datas[i]);
        }
    }

    public void SetDetail(ref SP_LoadPost data)
    {
        _postDetale.SetContent(data);
    }


    private void Awake()
    {
        GameManager.Instance._post.ResistObserver(this);
    }



}
