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
        _size = (short)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CP_StageProcess));
        _index = (short)Common.eCPacket.eCP_StageProcess;
        _encrypted = new byte[ENCRYPTED_SIZE];
        _stage = 0;
        _achieve = 0;
    }
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.ENCRYPTED_SIZE)]
    public byte[] _encrypted;
    public short _stage;
    public short _achieve;
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
    
    public void Clear(short achivement)
    {
     
            CP_StageProcess cp = new CP_StageProcess(0);

            byte[] plainText = Encoding.UTF8.GetBytes(GameManager.Instance._player.NickName);
            cp._encrypted = Crypto.Encrypt(plainText);


            //byte[] decrypted = Crypto.Decrypt(cp._encrypted);
            //string result = Encoding.UTF8.GetString(decrypted);

            cp._stage = highestStage;
            cp._achieve = achivement;
            highestStage++;

            GameManager.Instance._packetManager.Send(cp, cp._size);

    }
}
