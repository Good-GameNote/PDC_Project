using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tab : MonoBehaviour,IObserver<Common.ePage>
{
    [SerializeField]
    Common.ePage _thisButton;
    [SerializeField]
    GameObject _view;
    // [SerializeField]
    // UnityEngine.UI.Text _tabNameText;
    
    RectTransform _rectTransform;
    Vector2 sizeDelta;
    public void Set(Common.ePage data)
    {

        _view.SetActive(_thisButton==data);

        sizeDelta.x = _thisButton == data ? 180 : 135;

        _rectTransform.sizeDelta = sizeDelta;

        // _tabNameText.gameObject.SetActive(sizeDelta.x >= 180);
        
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        sizeDelta = _rectTransform.sizeDelta;

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => PageController.Instance.SetCurrentPage(_thisButton));


        PageController.Instance.ResistObserver(this);
        
        // _tabNameText.gameObject.SetActive(sizeDelta.x >= 180);
    }
}
