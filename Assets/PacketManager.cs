
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using static Common;

public class PacketManager : MonoBehaviour
{
    public static Socket sock;
    public string _Ip;
    private int _Port = 9090;

    private CM_Test _SendPacket = new CM_Test(0);
    private SM_Test _ReceivePacket;
    byte[] _Packet = new byte[1024];

    private IPEndPoint _ServerIpEndPoint;
    private Queue<byte[]> _PacketQueue = new();
    private Action<byte[]>[] mPacketFunc = new Action<byte[]>[(int)ePacketIndex.MAX_FUNC_SIZE];

    public void Send(object obj, int size)
    {
        // int size = Marshal.SizeOf(typeof(T));
        byte[] arr = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);
        unsafe
        {
            byte* bytePtr = (byte*)ptr.ToPointer();
            for (int i = 0; i < size; i++)
            {
                bytePtr[i] = 0;
            }
        }
        Marshal.StructureToPtr(obj, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);

        _PacketQueue.Enqueue(arr);
    }
    public void Recieve<T>(int index, Action<T> function) 
    {
        if (index < 0 || index >= (int)Common.ePacketIndex.MAX_FUNC_SIZE)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        mPacketFunc[index] = (byte[] packet) => { function(ByteToStruct<T>(packet)); } ;
    }


   
    private T ByteToStruct<T>(byte[] buffer)
    {
        int size = BitConverter.ToInt16(buffer, 0);
        IntPtr ptr = Marshal.AllocHGlobal(size);
        unsafe
        {
            byte* bytePtr = (byte*)ptr.ToPointer();
            for (int i = 0; i < size; i++)
            {
                bytePtr[i] = 0;
            }
        }
        Marshal.Copy(buffer, 0, ptr, size);
        T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
        Marshal.FreeHGlobal(ptr);
        return obj;
    }

    void InitClient()
    {
        _ServerIpEndPoint = new IPEndPoint(IPAddress.Parse(_Ip), _Port);
        sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        sock.Connect(_ServerIpEndPoint);
    }

     void Awake()
    {
        InitClient();
        Buffer.BlockCopy(Encoding.Unicode.GetBytes("클라"), 0, _SendPacket._StringlVariable, 0, 4);
        Send(_SendPacket, _SendPacket._size);

        Recieve<SM_Test>((int)ePacketIndex.eSM_Test, (p) =>
        {
            Debug.Log(Encoding.Unicode.GetString(p._StringlVariable));
        });
    }





    private void Update()
    {
        if (_PacketQueue.Count > 0)
        {
            byte[] packet =_PacketQueue.Dequeue();
            sock.Send(packet, 0, packet.Length, SocketFlags.None);
        }

        if (sock.Available != 0)
        {
            
            sock.Receive(_Packet, 0, sock.Available, SocketFlags.None);
            short index = BitConverter.ToInt16(_Packet, 2);

            if (index >= 0 && index < (short)ePacketIndex.MAX_FUNC_SIZE)
            {
                mPacketFunc[index](_Packet);
            }
        }
    }

    void CloseClient()
    {
        if (sock != null)
        {
            sock.Close();
            sock = null;
        }
    }

    void OnApplicationQuit()
    {
        CloseClient();
        Debug.Log("접속종료");
    }
}