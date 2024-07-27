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

public class Post : MonoBehaviour, ISubject<(SP_LoadPost,bool)> 
{

    List<SP_LoadPost> _postList = new List<SP_LoadPost>();


    private void Awake()
    {
        GameManager.Instance._packetManager.Recieve<SP_LoadPost>((int)Common.eSPacket.eSP_LoadPosts, (p) =>
        {
            _postList.Add(p);

            NotifyObservers((p, true));
        });
    }
    public void Reciept(int idx)
    {
        CP_Reciept cp = new CP_Reciept(0);

        cp.idx = idx;
        SP_LoadPost post = _postList.Find(p => p.idx == idx);

        _postList.Remove(post);
        NotifyObservers((post,false));
        GameManager.Instance._packetManager.Send(cp, cp._size);
    }

    IObserver<(SP_LoadPost, bool)> _observer;
    public void ResistObserver( IObserver<(SP_LoadPost,bool)> observer)
    {
        _observer = observer;
        foreach(SP_LoadPost post in _postList)
        {
            NotifyObservers((post, true));
        }
    }

    public void NotifyObservers((SP_LoadPost, bool) data)
    {
        if (_observer == null) return;
        _observer.Set(data);
    }
}
