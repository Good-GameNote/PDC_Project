using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct Mercenary
{
    short level;
};

struct SP_LoadMercenarys
{
    public SP_LoadMercenarys(int i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadMercenarys;
        mercenarys = new Mercenary[(int)eMercenary.MAX_MERCENARY_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMercenary.MAX_MERCENARY_SIZE)]
    public Mercenary[] mercenarys;
};
public class Team : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SP_LoadMercenarys>((int)ePacket.eSP_LoadMercenarys, (p) =>
        {
            Debug.Log(p.mercenarys);
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
