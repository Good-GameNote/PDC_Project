using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Money : MonoBehaviour, IObserver<int[]>
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _gold;

    [SerializeField]
    private TMPro.TextMeshProUGUI _dia;

    [SerializeField]
    private TMPro.TextMeshProUGUI _energy;
    public void Set(int[] data)
    {
        _gold.text = data[(int)Common.eMoney.eGold].ToString();
        _dia.text = data[(int)Common.eMoney.eDiamond].ToString();
        _energy.text = data[(int)Common.eMoney.eEnerge].ToString();


    }

}
