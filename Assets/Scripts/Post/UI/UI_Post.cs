using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Post : Singleton<UI_Post>, IObserver<(SP_LoadPost,bool)>
{

    [SerializeField]
    UI_PostSlot _slotPrefab;
    List<UI_PostSlot> _slots = new List<UI_PostSlot>();

    [SerializeField]
    Transform _slotsParent;

    [SerializeField]
    UI_PostIn _postDetale;


    public void Set((SP_LoadPost,bool) data)
    {
       if(data.Item2)
        {
            UI_PostSlot slot = Instantiate(_slotPrefab, _slotsParent);
            slot.SetContent(data.Item1);
            _slots.Add(slot);
        }else
        {
            UI_PostSlot slot = _slots.Find((el) => { return el.IsMatch(data.Item1); });
            Destroy(slot.gameObject);
            _slots.Remove(slot);
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
    private void OnEnable()
    {
        _postDetale.gameObject.SetActive(false);
    }


}
