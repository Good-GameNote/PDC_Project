using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;



public class Field :  Singleton<Field>
{
    //18초 마다 다음 라운드 시작.
    //라운드 시작시 20마리를 0.5초 마다 생성.


    short _curRound = 0;
    short _roundEleapse=18;
    float _enemySponEleapse = 0.5f;

    [field: SerializeField]
    public short _Wide { get; private set; }
    [field: SerializeField]
    public short _height { get; private set; }
    [SerializeField]
    short _enemyCountByRound=20;

    short _curRemainEnemyCount=0;


    [SerializeField]
    public Transform _enemySpot;
    private void Awake()
    {
    }

    public void StartWave()
    {

        _enemySpot = _enemySpot. GetChild(0).GetChild(0);
        StartCoroutine(RoundUpper());
        Catsle.Instance.Init();
    }

    [SerializeField]
    TMPro.TextMeshProUGUI _tRound;
    IEnumerator RoundUpper()
    {

        yield return new WaitForSeconds(3);

        while (_curRound<21)
        {

            _curRound++;
            
            _tRound.text =$"Wave {_curRound} / 20" ;
            _curRemainEnemyCount = _enemyCountByRound;
            StartCoroutine(ExcutePool());

            yield return new WaitForSeconds(_roundEleapse);            
            
        }
        Clear();

    }

    IEnumerator ExcutePool()
    {
        while (_curRemainEnemyCount>0)
        {
            _curRemainEnemyCount--;
            EnemyPool.Instance.Get(_enemySpot.position);
            yield return new WaitForSeconds(_enemySponEleapse);
        }

    }

    

    [SerializeField]
    Reward[] _rewards;

    [SerializeField]
    UI_End _ender;

    List<ICardExhibition>_posts = new List<ICardExhibition>();
    void Clear()
    {
        _posts.Clear();
        Stage info = GameManager.Instance._battle.sellectStage;

        float stage = (info.stage.index+1) *0.2f; //현 스테이지 *0.2
        short achivement = Catsle.Instance.GiveAchivement(); //달성도
        

        for (int i =0; i<3; i++)
        {

            int rewardIdx = Random.Range(0, info.Rewards.Length);

            Reward post = _rewards [(int)info.Rewards[rewardIdx]];
            post.SetValue(stage * achivement/3);
            if(i==0)
            {
                GameManager.Instance._battle.Clear(achivement, post);
            }
            _posts.Add ( post);

        }

        _ender.IsClear(_posts, achivement);

    }

}
