using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_End : MonoBehaviour
{
    [SerializeField]
    GameObject _complete;
    [SerializeField]
    UI_CardSellecter _cardSellecter;


    [SerializeField]
    GameObject _defeat;

    [SerializeField]
    SceneLoader _sceneLoader;

    [SerializeField]
    GameObject[] _stars;
    public void Next()
    {
        GameManager.Instance._battle.ChangeStage(true);
        _sceneLoader.LoadScene("BattleScene1");
    }
    public void IsClear(ICardExhibition[] rewards = null,short achivement=0)
    {
        for (short i = 0; i < 3; i++)
        {
            _stars[i].SetActive(i < achivement);
        }
        gameObject.SetActive(true);
        _defeat.SetActive(rewards == null);
        _complete.SetActive(rewards != null);

        _cardSellecter.SetCard(rewards);


    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
