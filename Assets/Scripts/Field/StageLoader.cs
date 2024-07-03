using System;
using System.Collections;
using System.Collections.Generic;
using TWC;
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
    mapInfo[] _mapInfos = new mapInfo[]
    {
        new(2, new Vector3(23,0,99),new Vector3(5,0,117) ),
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

    public mapInfo CurrentMapInfo { get; private  set; }

    private void Awake()
    {
        //short index = GameManager.Instance._battle.sellectStage.stage.index;

        //CurrentMapInfo = _mapInfos[index];
        //twc.SetCustomRandomSeed(_mapInfos[index]._seed);

        //string name = _stageNames[index / 10];
        //var _path = Application.dataPath + $"/Resources/Twm/{name}.json";
        //twc.LoadBlueprintStackAndExecute(_path);
    }
    public void OnEnable()
    {
        twc.OnBlueprintLayersComplete += BuildMap;
    }


    void BuildMap(TileWorldCreator _twc)
    {
        _twc.ExecuteAllBuildLayers(false);
    }


}
