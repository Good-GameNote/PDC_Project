using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public struct CP_Contect
{
    const  short subjectSize = 15;
    const  short uuidSize =21;
    const  short explaneSize = 150;
    public CP_Contect(int i)
    {
        _size = (short)Marshal.SizeOf(typeof(CP_Contect));
        _index = (short)Common.eCPacket.eCP_Contect;
        _subject = new byte[subjectSize * 2];
        _uuid = new byte[uuidSize ];
        _explane = new byte[explaneSize * 2];
    }
    public short _size;
    public short _index;


    [MarshalAs(UnmanagedType.ByValArray, SizeConst = subjectSize * 2)]
    public byte[] _subject;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = explaneSize * 2)]
    public byte[] _explane; 
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = uuidSize)]
    public byte[] _uuid;

};

public class UI_Contect : MonoBehaviour
{
    [SerializeField]
    Text _subject;
    [SerializeField]
    Text _uuid;
    [SerializeField]
    Text _explane;
    // Start is called before the first frame update

   public void SendContectMessage()
    {        
        CP_Contect cp = new CP_Contect(0);
        System.Buffer.BlockCopy(Encoding.Unicode.GetBytes(_subject.text), 0,cp._subject , 0, _subject.text.Length * 2);
        System.Buffer.BlockCopy(Encoding.UTF8.GetBytes(_uuid.text), 0, cp._uuid, 0, _uuid.text.Length );
        System.Buffer.BlockCopy(Encoding.Unicode.GetBytes(_explane.text), 0, cp._explane, 0, _explane.text.Length * 2);

        GameManager.Instance._packetManager.Send(cp,cp._size);
    }



}
