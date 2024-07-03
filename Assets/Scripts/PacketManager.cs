
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using static Common;
using TWC.OdinSerializer;
using System.Drawing;
using Unity.Burst.Intrinsics;

public class PacketManager : MonoBehaviour
{
    public static Socket sock;
    public string _Ip;
    private int _Port = 9090;

    byte[] _Packet = new byte[MAX_PACKET_SIZE];

    private IPEndPoint _ServerIpEndPoint;
    private Action<byte[]>[] mPacketFunc = new Action<byte[]>[(int)eSPacket.MAX_SPACKET_SIZE];

    readonly float sendElapse = 0.5f;
    float sendCool ;


    public bool Send(object obj, int size)
    {
        if(sendCool < sendElapse)
        {
            return false;
        }
        sendCool -= sendElapse;

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

        //_sendQueue.Enqueue(arr);
        Debug.Log($"cp index = {BitConverter.ToInt16(arr, 2)}");
        sock.Send(arr, 0, size, SocketFlags.None);
        return true;
    }
    public void Recieve<T>(int index, Action<T> function) 
    {
        if (index < 0 || index >= (int)Common.eSPacket.MAX_SPACKET_SIZE)
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
        sendCool = sendElapse;
        InitClient();
      
        sock.BeginReceive(_Packet, 0, _Packet.Length, SocketFlags.None, new AsyncCallback(OnReceive), sock);
        
    }
    void OnReceive(IAsyncResult ar)
    {
        try
        {
            Socket client = (Socket)ar.AsyncState ; //             
            int bytesRead = client.EndReceive(ar);
            if (bytesRead > 0)
            {
                byte[] tempBuffer = new byte[bytesRead];
                Buffer.BlockCopy(_Packet, 0, tempBuffer, 0, bytesRead);
                _executionQueue.Enqueue(tempBuffer);
            }
            client.BeginReceive(_Packet, 0, _Packet.Length, SocketFlags.None, new AsyncCallback(OnReceive), client);
        }
        catch (SocketException e)
        {
            Debug.Log("SocketException: " + e.ToString());
        }
    }


    //private static readonly Queue<byte[]> _sendQueue = new ();
    private static readonly Queue<byte[]> _executionQueue = new Queue<byte[]>();

    byte[] _recieveBuffer;
    byte[] _sendBuffer;
    public void Update()
    {
        if(sendCool< sendElapse)
        {
            sendCool += Time.deltaTime;
        }
        if (_executionQueue.Count > 0)
        {
            _recieveBuffer = _executionQueue.Dequeue();
            short index = BitConverter.ToInt16(_recieveBuffer, 2);

            if (index >= 0 && index < (short)eSPacket.MAX_SPACKET_SIZE)
            {
                Debug.Log($"SPIndex : {index}");
                mPacketFunc[index](_recieveBuffer);
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