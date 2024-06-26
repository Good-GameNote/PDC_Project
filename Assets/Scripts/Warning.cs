using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class Warning : MonoBehaviour
{

    [SerializeField]
    UnityEngine.UI.Text _warningText;
    [SerializeField]
    RectTransform _warningRectTransform;

    string[] _translatesText = {"성공","재화가 부족합니다.","레벨이 부족합니다.","이미 존재합니다.",
        "비속어가 있습니다.","너무 깁니다.","너무많습니다.","존재하지 않습니다"};
    Color _warningColor;

    private void Awake()
    {
        GameManager.Instance._warning = this;
    }
    private Coroutine myCoroutine;
    public void Show(Common.All_ERROR errorType)
    {
        if (myCoroutine != null)
            StopCoroutine(myCoroutine);
        _warningText.text = _translatesText[(int)errorType];
        _warningRectTransform.anchoredPosition = Vector3.zero;
        _warningColor.a = 1;
        _warningText.gameObject.SetActive(true);
        myCoroutine = StartCoroutine(ShowActionForSeconds(2f));

    }

    private IEnumerator ShowActionForSeconds(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            _warningRectTransform.anchoredPosition += Vector2.up * Time.deltaTime*50;
            _warningColor.a -= Time.deltaTime;
            _warningText.color = _warningColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _warningText.gameObject.SetActive(false);
    }

}
