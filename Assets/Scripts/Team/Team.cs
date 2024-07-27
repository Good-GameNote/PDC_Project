using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sMercenary:IServerData
{
    public short index;
    public short level;
    public short surplus;
    public short GiveIndex()
    {
        return index;
    }
    public short GiveLevel()
    {
        return level;
    }

    public short GiveSurplus()
    {
        return surplus;
    }
};

struct SP_LoadMercenarys
{
    public SP_LoadMercenarys(int i)
    {
        _size = 44;
        _index = (short)eSPacket.eSP_LoadMercenarys;
        mercenarys = new sMercenary[(int)eMercenary.MAX_MERCENARY_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMercenary.MAX_MERCENARY_SIZE)]
    public sMercenary[] mercenarys;
};
public class Team : MonoBehaviour, IIndexableSubject<sMercenary[]>
{
    sMercenary[][] _mercenarys;

    public void NotifyObservers(short index)
    {
        observers[index].Set(_mercenarys[index]);
    }
    IObserver<sMercenary[]>[] observers = new IObserver<sMercenary[]>[(int)eMercenary.MAX_MERCENARY_SIZE];
    public void ResistObserver(short index, IObserver<sMercenary[]> observer)
    {
        observers[index] = observer;
    }

    private void Awake()
    {
        _mercenarys = new sMercenary[(int)eMercenary.MAX_MERCENARY_SIZE][];
        for (int i = 0; i < (int)eMercenary.MAX_MERCENARY_SIZE; i++)
        {
            _mercenarys[i] = new sMercenary[1];
        }
        GameManager.Instance._packetManager.Recieve<SP_LoadMercenarys>((int)eSPacket.eSP_LoadMercenarys, (p) =>
        {
            for (int i = 0; i < (int)eMercenary.MAX_MERCENARY_SIZE; i++)
            {
                _mercenarys[i][0]=p.mercenarys[i];

                Debug.Log(p.mercenarys[i]);
            }
            Debug.Log(p.mercenarys);
        });
    }

}
