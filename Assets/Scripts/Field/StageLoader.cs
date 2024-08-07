using System;
using System.Collections;
using System.Collections.Generic;
using TWC;
using Unity.AI.Navigation;
using UnityEngine;



public class StageLoader : Singleton<StageLoader> 
{
    [SerializeField]
    TileWorldCreator twc;

    string[] _stageNames = new string[]
    {
        "sea",
        "desert",
        "sea",
        "sea",
        "sea",
        "sea",
        "sea",
        "sea",
        "sea",
        "sea",
    };

    [SerializeField]
    NavMeshSurface _path;
    [SerializeField]
    TMPro.TextMeshProUGUI _tStage;
    [SerializeField]
    short[] seeds = {1, 2, 3, 4, 5, 6, 7 };


    private void Awake()
    {

        short index = GameManager.Instance._battle.sellectStage.stage.index;
        _tStage.text =$"Stage {index + 1}" ;
        //short index = 1;
        twc.SetCustomRandomSeed(seeds[index]);
        string name = _stageNames[index / 10];
   
        string filePath = $"Twm/{name}";

        twc.LoadBlueprintStackAndExecute(filePath);

       twc.ExecuteAllBuildLayers(false);

    }
    public void OnEnable()
    {

        twc.OnBlueprintLayersComplete += BuildMap;
        twc.OnBuildLayersComplete += BuildMap2;
    }


    void BuildMap(TileWorldCreator _twc)
    {
        _twc.ExecuteAllBuildLayers(false);
    }
    [SerializeField]
    Field _field;
    void BuildMap2(TileWorldCreator _twc)
    {
        _path.BuildNavMesh();
        _field.StartWave();
    }




}
