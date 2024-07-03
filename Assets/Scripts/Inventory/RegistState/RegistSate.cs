
using UnityEngine;



public abstract class RegistSate :MonoBehaviour
{

 

    [SerializeField]
    protected RegistSate other;

    public bool Change(ref RegistSate self, bool sendPacket)
    {
        Relic relic = Relic.CurrentRelic;
        bool result = InChange(ref self, relic,sendPacket);
        if (!result)
            return result;

        relic.transform.SetParent(other.transform);
        relic.transform.SetSiblingIndex(relic.GiveIndex());

        return result;
    }
    protected abstract bool InChange(ref RegistSate self , Relic relic, bool sendPacket);


}

public struct CP_RegistRelic
{
    public CP_RegistRelic(int i)
    {
        _size = (short)System.Runtime.InteropServices.Marshal.SizeOf(typeof(CP_RegistRelic));
        _index = (short)Common.eCPacket.eCP_RegistRelic;
        _relicIndex = 0;
        _bitDeckNum = 0;
    }
    public short _size;
    public short _index;
    public short _relicIndex;
    public short _bitDeckNum;
};