using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gacha : MonoBehaviour
{
    [SerializeField]
    Common.ePage type;
    Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            switch (type)
            {
                case Common.ePage.eInven:
                    GameManager.Instance._inven.Gach();
                    break;
            }
        });
    }

}
