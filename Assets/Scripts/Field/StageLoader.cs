using System;
using System.Collections;
using System.Collections.Generic;
using TWC;
using Unity.AI.Navigation;
using UnityEngine;

public class mapInfo
{

    public short _seed;
    public Vector3 _enemySpot;
    public Vector3 _castlePoint;
    public mapInfo(short seed,Vector3 enemySpot,  Vector3 catslePoint) { _seed = seed;_enemySpot = enemySpot; _castlePoint = catslePoint; }
}
public class StageLoader : Singleton<StageLoader> 
{
    [SerializeField]
    TileWorldCreator twc;
    static mapInfo[] _mapInfos = new mapInfo[]
    {
        new(3, new Vector3(2.45f,0.5f,93.5f),new Vector3(8.5f,1.5f,108.5f) ),
        new (9, new Vector3(7.5f,0.5f,108.5f),new Vector3(16.5f,1.5f,93.5f) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
       new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
                new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
                new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
          new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
                new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) ),
         new(0, new Vector3(0,0,0),new Vector3(0,0,0) ),
        new (0, new Vector3(0,0,0),new Vector3(0,0,0) )
    };
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

    public mapInfo CurrentMapInfo { get; private  set; }

    private void Awake()
    {
        short index = GameManager.Instance._battle.sellectStage.stage.index;
        //short index = 1;
        CurrentMapInfo = _mapInfos[index];
        twc.SetCustomRandomSeed(_mapInfos[index]._seed);
        string name = _stageNames[index / 10];
        var filepath = Application.dataPath + $"/Resources/Twm/{name}.json";
        twc.LoadBlueprintStackAndExecute(filepath);

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
