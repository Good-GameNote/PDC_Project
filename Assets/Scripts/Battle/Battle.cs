using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
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


public struct CP_StageProcess
{
    public CP_StageProcess(int i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_StageProcess));
        _index = (short)Common.eCPacket.eCP_StageProcess;
        _encrypted = new byte[ENCRYPTED_SIZE];
        _stage = 0;
        _achieve = 0;
        _type = 0;
        _value = 0;
    }
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.ENCRYPTED_SIZE)]
    public byte[] _encrypted;
    public int _value;
    public short _type;
    public short _stage;
    public short _achieve;
};


public class Battle : MonoBehaviour, ISubject<Stage>
{
    [SerializeField]
    Stage[] stages;

    public Stage sellectStage { get; private set; }

    public void ChangeStage(short stageNum)
    {
        if(stageNum>HighestStage)
        {
            Debug.Log("최고스테이지보다 높을수 없습니다.");
            return;
        }

        CP_ChangeOption cp = new CP_ChangeOption(0);
        cp._type = (short)eOption.eSellectStage;
        cp._deckNum = stageNum;
        GameManager.Instance._packetManager.Send(cp, cp._size);

        sellectStage = stages[stageNum];
        NotifyObservers(sellectStage);
    }

    public void ChangeStage(bool isNext)
    {
        short nextStage = sellectStage.stage.index;
        if (isNext)
        {
            nextStage++;
        } else
        {
            nextStage--;
        }
        if (nextStage > HighestStage)
        {
            Debug.Log("최고스테이지보다 높을수 없습니다.");
            return;
        }else if(nextStage<0)
        {
            Debug.Log("최저스테이지보다 낮을수 없습니다.");
            return;
        }

        sellectStage = stages[nextStage];

        CP_ChangeOption cp = new CP_ChangeOption(0);
        cp._type = (short)eOption.eSellectStage;
        cp._deckNum = nextStage;
        GameManager.Instance._packetManager.Send(cp, cp._size);
        NotifyObservers(sellectStage);
    }

    public short HighestStage { get; private set; }

    List<IObserver<Stage>> observers = new ();
    public void ResistObserver(IObserver<Stage> observer)
    {
        observers.Add(observer);
        if(observers.Count >= 1)
        {
            NotifyObservers(sellectStage);
        }
    }

    List<IObserver<short>> HighStageObservers = new();
    public void ResistObserver(IObserver<short> observer)
    {
        HighStageObservers.Add(observer);
     
        NotifyObservers(sellectStage);
        
    }
    public void NotifyObservers(Stage sellectStage)
    {
        foreach (var observer in observers)
        {
            observer?.Set(sellectStage);
        }
        foreach (var observer in HighStageObservers)
        {
            observer?.Set(HighestStage);
        }

    }
    private void Awake()
    {
        GameManager.Instance._packetManager.Recieve<SP_LoadStages>((int)eSPacket.eSP_LoadStages, (p) =>
        {
            for(int i = 0; i < MAX_STAGE_SIZE; i++) 
            {
                stages[i].stage = p.stages[i];
            }
            sellectStage = stages[p.curStage];
            HighestStage = p.highestStage;
            Debug.Log(p.stages);
        });
    }

    public void Clear( short achivement, Reward reward)
    {

        CP_StageProcess cp = new CP_StageProcess(0);

        byte[] plainText = Encoding.UTF8.GetBytes(GameManager.Instance._player.NickName);
        cp._encrypted = Crypto.Encrypt(plainText);
        sellectStage.stage.Achievement = achivement;

        cp._stage = sellectStage.stage.index;
        cp._achieve = achivement;
        cp._type = (short)reward.Type;
        cp._value = reward.Value;
        if(HighestStage == sellectStage.stage.index)
        {
            HighestStage++;
        }

        GameManager.Instance._packetManager.Send(cp, cp._size);

    }
}
