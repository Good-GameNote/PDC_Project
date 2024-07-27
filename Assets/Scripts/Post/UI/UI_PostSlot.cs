using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class UI_PostSlot : MonoBehaviour
{
    SP_LoadPost _data;
    int idx;
    [SerializeField]
    Text _title;
    [SerializeField]
    Text _fromNick;
    [SerializeField]
    Text _CreateAt;

    [SerializeField]
    Button _sellectButton;

    private void Awake()
    {
        _sellectButton.onClick.AddListener(() => { UI_Post.Instance.SetDetail(ref _data); });
    }
    public void SetContent(SP_LoadPost data)
    {
        _data = data;
        idx = data.idx;
        _title.text = Encoding.Unicode.GetString(data.title);
        // _CreateAt.text = Common.UnixTimeStampToDateTime(data.createdAt).ToString();

    }
    public bool IsMatch(SP_LoadPost data)
    {
        return data.idx == idx;
    }



}
