using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

using UnityEngine.UI;

public class UI_PostIn : MonoBehaviour
{
    [SerializeField]
    Text _title;
    [SerializeField]
    Text _fromNick;
    [SerializeField]
    Text _contents;

    [SerializeField]
    Button _recieptButton;


    SP_LoadPost cur;

    public void SetContent(SP_LoadPost sellected)
    {
        cur = sellected;
        _title.text = Encoding.Unicode.GetString(cur.title);
       // _fromNick.text = Encoding.Unicode.GetString(cur.fromNick);
        _contents.text = Encoding.Unicode.GetString(cur.message);
        gameObject.SetActive(true);

    }
    void Awake()
    {

        _recieptButton.onClick.AddListener(() => { GameManager.Instance._post.Reciept(cur.idx);gameObject.SetActive(false); });
    }

  
}
