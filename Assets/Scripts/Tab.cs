using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tab : MonoBehaviour,IObserver<Common.ePage>
{
    [SerializeField]
    Common.ePage _thisButton;
    [SerializeField]
    GameObject _view;
    
    RectTransform _rectTransform;
    Vector2 sizeDelta;
    public void Set(Common.ePage data)
    {

        _view.SetActive(_thisButton==data);

        sizeDelta.x = _thisButton == data ? 180 : 135;

        _rectTransform.sizeDelta = sizeDelta;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        sizeDelta = _rectTransform.sizeDelta;

        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => GameManager.Instance._pageController.SetCurrentPage(_thisButton));


        GameManager.Instance._pageController.ResistObserver(this);
    }
}
