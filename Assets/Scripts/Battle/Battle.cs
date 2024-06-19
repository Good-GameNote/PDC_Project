using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sStage
{
    short Achievement;
};
struct SP_LoadStages
{
    public SP_LoadStages(int i)
    {
        _size = 44;
        _index = (short)eSPacket.eSP_LoadStages;
        stages = new sStage[Common.MAX_STAGE_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.MAX_STAGE_SIZE)]
    public sStage[] stages;
};
public class Battle : MonoBehaviour
{
    sStage[] stages;
    private void Awake()
    {
        stages = new sStage[Common.MAX_STAGE_SIZE];
        GameManager.Instance._packetManager.Recieve<SP_LoadStages>((int)eSPacket.eSP_LoadStages, (p) =>
        {
            for(int i = 0; i < MAX_STAGE_SIZE; i++) 
            {
                stages[i] = p.stages[i];
            }
            Debug.Log(p.stages);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
