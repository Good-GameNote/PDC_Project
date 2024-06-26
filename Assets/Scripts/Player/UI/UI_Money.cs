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


    private void Awake()
    {
        GameManager.Instance._player.ResistObserver(this);
        GameManager.Instance._player.NotifyObservers();
    }
    public void Set(int[] data)
    {        
        _gold.text = "0";
        _gold.text = data[(int)Common.eMoney.eGold].ToString();
        _dia.text = (data[(int)Common.eMoney.eDiamond]).ToString();
        _energy.text = (data[(int)Common.eMoney.eEnerge]).ToString();

    }

}
