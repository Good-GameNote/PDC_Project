using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sStage
{
    public short index;
    public short Achievement;
};
struct SP_LoadStages
{    
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.MAX_STAGE_SIZE)]
    public sStage[] stages;

    public short highestStage ;
    public short curStage;
};
public class Battle : MonoBehaviour, ISubject<Stage>
{
    [SerializeField]
    Stage[] stages;

    public Stage sellectStage { get; private set; }
    short highestStage;
    public void NotifyObservers()
    {
        foreach(var observer in observers)
        {
            observer?.Set(sellectStage);
        }
    }
    List<IObserver<Stage>> observers = new ();
    public void ResistObserver(IObserver<Stage> observer)
    {
        observers.Add(observer);
        if(observers.Count >= 1)
        {
            NotifyObservers();
        }
    }

    private void Awake()
    {
        //stages = new Stage[Common.MAX_STAGE_SIZE];
        GameManager.Instance._packetManager.Recieve<SP_LoadStages>((int)eSPacket.eSP_LoadStages, (p) =>
        {
            for(int i = 0; i < MAX_STAGE_SIZE; i++) 
            {
                stages[i].stage = p.stages[i];
            }
            sellectStage = stages[p.curStage];
            highestStage = p.highestStage;
            Debug.Log(p.stages);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
