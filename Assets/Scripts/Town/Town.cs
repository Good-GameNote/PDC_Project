using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using static Common;



public struct sBuilding
{
  public  short level;
};
struct SP_LoadTown
{
    public SP_LoadTown(int i)
    {
        _size = 44;
        _index = (short)eSPacket.eSP_LoadTown;
        buildings = new sBuilding[(int)eBuilding.MAX_BUILDING_SIZE];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eBuilding.MAX_BUILDING_SIZE)]
    public sBuilding[] buildings;
};
public class Town : MonoBehaviour,ITownSubject
{
    sBuilding[] sBuilding;

    List<ITownObserver> observers = new ();


    short _count = 0;
    short _totalLevel=0;
    public void NotifyObservers()
    {
        foreach (var observer in observers) { observer.Set(_count,_totalLevel); }
    }

    public void ResistObserver(ITownObserver observer)
    {
        observers.Add(observer);
    }

    private void Awake()
    {
        sBuilding = new sBuilding[(int)eBuilding.MAX_BUILDING_SIZE];
        GameManager.Instance._packetManager.Recieve<SP_LoadTown>((int)eSPacket.eSP_LoadTown, (p) =>
        {
            for (int i = 0; i < (int)eBuilding.MAX_BUILDING_SIZE; i++)
            {
                sBuilding[i] = p.buildings[i];
                if (sBuilding[i].level != 0)
                {
                    _count++;
                    _totalLevel += sBuilding[i].level;
                }

                Debug.Log(p.buildings);
            }
        });
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
}
