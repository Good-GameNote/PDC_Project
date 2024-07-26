using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;


public struct SP_LoadPost
{
    public short _size;
    public short _index;

    public int idx;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15*2)]
    public byte[] title;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = Common.MAX_NICKNAME_SIZE*2)]
    public byte[] fromNick;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100*2)]
    public byte[] message;
    public short type;
    public int value;
    public long createdAt;
};




public struct CP_Reciept
{
    public CP_Reciept(int i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_Reciept));
        _index = (short)Common.eCPacket.eCP_Reciept;

        idx = 0;
    }
    public short _size;
    public short _index;

    public int idx ;
};

public class Post : MonoBehaviour,ISubject<List<SP_LoadPost>> 
{

    List<SP_LoadPost> _postList = new List<SP_LoadPost>();
    private void Awake()
    {
        GameManager.Instance._packetManager.Recieve<SP_LoadPost>((int)Common.eSPacket.eSP_LoadPosts, (p) =>
        {
            _postList.Add(p);

            string test = Encoding.Unicode.GetString(p.message);

            test = Encoding.Unicode.GetString(p.fromNick);
            Debug.Log("post"+p);
        });
    }
    public void Reciept(int idx)
    {
        CP_Reciept cp = new CP_Reciept(0);

        cp.idx = idx;
        _postList.RemoveAll(p => p.idx == idx);
        GameManager.Instance._packetManager.Send(cp, cp._size);

    }

    List< IObserver<List<SP_LoadPost>>> observers = new List<IObserver<List<SP_LoadPost>>>();

    public void ResistObserver(IObserver<List<SP_LoadPost>> observer)
    {
        observers.Add(observer);
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Set(_postList);
        }
    }
}
