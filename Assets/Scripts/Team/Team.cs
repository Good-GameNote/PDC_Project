using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sMercenary
{
    short level;
};

struct SP_LoadMercenarys
{
    public SP_LoadMercenarys(int i)
    {
        _size = 44;
        _index = (short)ePacket.eSP_LoadMercenarys;
        mercenarys = new sMercenary[(int)eMercenary.MAX_MERCENARY_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMercenary.MAX_MERCENARY_SIZE)]
    public sMercenary[] mercenarys;
};
public class Team : MonoBehaviour
{
    sMercenary[] _sMercenarys;
    private void Awake()
    {
        _sMercenarys = new sMercenary[(int)eMercenary.MAX_MERCENARY_SIZE];
        GameManager.Instance._packetManager.Recieve<SP_LoadMercenarys>((int)ePacket.eSP_LoadMercenarys, (p) =>
        {
            for(int i =0; i<(int)eMercenary.MAX_MERCENARY_SIZE; i++)
            {
                _sMercenarys[i] = p.mercenarys[i];
            }
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
