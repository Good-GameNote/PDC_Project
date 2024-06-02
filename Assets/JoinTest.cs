using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


using static Common;

[Serializable]
public struct CM_Join
{
    public CM_Join(byte i)
    {
        _size = 60;  
        _index = (short)ePacketIndex.eCM_Join;
        _token = new byte[TOKEN_SIZE*2];
        _nickName = new byte[MAX_NICKNAME_LENGTH * 2];
    }
    public short _size;
    public short _index;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = TOKEN_SIZE*2)]
    public byte[] _token;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_NICKNAME_LENGTH*2)]
    public byte[] _nickName;

}


[Serializable]
public struct SM_Join
{
    public short _size;
    public short _index;

    public short _result;//eNickCheck

}

public class JoinTest : MonoBehaviour
{
    [SerializeField]
    InputField nickField;
    [SerializeField]
    InputField tokenField;
    private void Awake()
    {
        GameManager.Instance.packetManager.Recieve<SM_Join>((int)ePacketIndex.eSM_Join, (p) =>
        {
            Debug.Log(p._result);
        });
    }
    public void SendJoinPacket()
    {
        CM_Join packet = new CM_Join(0);
        Buffer.BlockCopy(Encoding.Unicode.GetBytes(nickField.text), 0, packet._nickName, 0, nickField.text.Length*2);
        Buffer.BlockCopy(Encoding.Unicode.GetBytes(tokenField.text), 0, packet._token, 0, tokenField.text.Length*2);

        GameManager.Instance.packetManager.Send(packet, packet._size);

    
    }
}
