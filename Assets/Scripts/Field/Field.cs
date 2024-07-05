using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Field : MonoBehaviour
{
    //18초 마다 다음 라운드 시작.
    //라운드 시작시 20마리를 0.5초 마다 생성.
    //몬스터 풀에서 현재 라운드에 맞는 몬스터 배열을 활성화 할필요 있음.

    short _curRound = 0;
    short _roundEleapse=18;
    float _enemySponEleapse = 0.5f;


    [SerializeField]
    short _enemyCountByRound=20;

    short _curRemainEnemyCount=0;

    private void Awake()
    {

    }

    public void StartWave()
    {

        StartCoroutine(RoundUpper());
    }

    IEnumerator RoundUpper()
    {
        while (_curRound<21)
        {
            _curRound++;
            _curRemainEnemyCount = _enemyCountByRound;
            StartCoroutine(ExcutePool());

            yield return new WaitForSeconds(_roundEleapse);            
            
        }
    }
    [SerializeField]
    EnemyPool pool;
    IEnumerator ExcutePool()
    {
        while (_curRemainEnemyCount>0)
        {
            _curRemainEnemyCount--;
            pool.Get();
            yield return new WaitForSeconds(_enemySponEleapse);
        }

    }

}
