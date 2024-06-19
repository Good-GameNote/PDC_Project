using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Setter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    UnityEngine.UI.Image image;
    void Start()
    {
    }
    public void Setting(string address)
    {
        image.sprite = GameManager.Instance._addressableLoader.GetLoadedResource<Sprite>(address);

    }
   
}
