using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caller : MonoBehaviour
{
    [SerializeField]
    string _loadSceneName;
    [SerializeField]
    Slider _slider;
    [SerializeField]
    TMPro.TextMeshProUGUI _progressText;
    // Start is called before the first frame update
    [SerializeField]
    Button _button;
    void Start()
    {
        GameManager.Instance._sceneLoader.LoadScene(_loadSceneName, _progressText, _slider,false,_button);
        
    }

}
