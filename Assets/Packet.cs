using System;
using System.Runtime.InteropServices;

using static Common;

[Serializable]
public struct CM_Test
{
    public CM_Test(int dummy)
    {
        _size = 20;
        _index = (short)ePacketIndex.eCM_Test;
        _StringlVariable = new byte[16];
    }
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] _StringlVariable;
}


[Serializable]
public struct SM_Test 
{
    public short _size;
    public short _index;
  
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] _StringlVariable;
}