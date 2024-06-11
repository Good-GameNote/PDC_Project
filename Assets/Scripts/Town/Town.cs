using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sBuilding
{
    short level;
};
struct SP_LoadTown
{
    public SP_LoadTown(int i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadTown;
        buildings = new sBuilding[(int)eBuilding.MAX_BUILDING_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eBuilding.MAX_BUILDING_SIZE)]
    public sBuilding[] buildings;
};
public class Town : MonoBehaviour
{
    sBuilding[] sBuilding;
    private void Awake()
    {
        sBuilding = new sBuilding[(int)eBuilding.MAX_BUILDING_SIZE];
        GameManager.Instance.packetManager.Recieve<SP_LoadTown>((int)ePacket.eSP_LoadTown, (p) =>
        {
            for(int i = 0; i< (int)eBuilding.MAX_BUILDING_SIZE; i++)
            {
                sBuilding[i] = p.buildings[i];
            }
            Debug.Log(p.buildings);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
}
