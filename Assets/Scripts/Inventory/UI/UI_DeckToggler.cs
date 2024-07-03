
using UnityEngine;

using UnityEngine.UI;
public class UI_DeckToggler : MonoBehaviour
{
    [SerializeField]
    Image img;
    Toggle toggle;

    short deckNum;

    Color origin;
    Color sellect;
    private void Awake()
    {        
        toggle = GetComponent<Toggle>();

        origin = img.color;
        sellect = new Color(0.80392f, 0.52941f, 1f);
        deckNum = (short) (transform.GetSiblingIndex() + 1);
        toggle.isOn = deckNum == GameManager.Instance._inven.CurDeckNum;
        toggle.onValueChanged.AddListener(Sellect);
        Sellect(toggle.isOn);
    }


    void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(Sellect);
    }

    public void Sellect(bool isOn)
    {
        img.color = isOn ?sellect : origin;
        if(isOn)
        {
            GameManager.Instance._inven.ChangeDeck(deckNum);
        }
    }

}

