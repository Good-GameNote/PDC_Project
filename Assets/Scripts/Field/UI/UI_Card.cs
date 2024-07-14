using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Card : MonoBehaviour
{
    // Start is called before the first frame update

    Common.eEffector cur;
    public void SetNum(Common.eEffector num)
    {
        gameObject.SetActive(true);
        cur = num;
    }

    private void Awake()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => { UI_MercenaryAction.Instance.Choice(Effector.Effectors[(int)cur]); });
    }


}
