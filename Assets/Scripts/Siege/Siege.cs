using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct Stage
{
    short Achievement;
};
struct SP_LoadStages
{
    public SP_LoadStages(int i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadStages;
        stages = new Stage[Common.MAX_STAGE_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.MAX_STAGE_SIZE)]
    public Stage[] stages;
};
public class Siege : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SP_LoadStages>((int)ePacket.eSP_LoadStages, (p) =>
        {
            Debug.Log(p.stages);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
