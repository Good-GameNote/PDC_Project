using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using static Common;


public struct Cash
{
    long _limiteAt;
    long _buyAt;
};


struct SP_LoadPlayer
{
    public short _size;
    public short _index;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_NICKNAME_SIZE*2)]
    public byte[] _nickName;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eMoney.MAX_MONEY_SIZE)]
    public int[] _money;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eCash.MAX_CASH_SIZE)]
    public Cash[] _cash;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)eTime.MAX_TIME_SIZE)]
    public long[] _time;
};


struct SP_RecordMoney
{
    
    public short _size;
    public short _index;

    public short moneyType;
    public short reason;
    public int value;
};


public class Player : MonoBehaviour, ISubject<int[]>
{
    string _nickName;
    //(int)eTime.MAX_TIME_SIZE (int)eCash.MAX_CASH_SIZE) (int)eMoney.MAX_MONEY_SIZE)
    public int[] _money;
    public Cash[] _cash;
    public long[] _time;
    private void Awake()
    {
        _money = new int[(int)eMoney.MAX_MONEY_SIZE];
        _cash = new Cash[(int)eCash.MAX_CASH_SIZE];
        _time = new long[(int)eTime.MAX_TIME_SIZE];

        GameManager.Instance._packetManager.Recieve<SP_LoadPlayer>((int)eSPacket.eSP_LoadPlayer, (p) =>
        {
            _nickName = Encoding.Unicode.GetString(p._nickName);

            _money = p._money;
            _cash = p._cash;
            _time = p._time;

            Debug.Log(_nickName);
        });
        GameManager.Instance._packetManager.Recieve<SP_RecordMoney>((int)eSPacket.eSP_RecordMoney, (p) =>
        {
            _money[p.moneyType] += p.value;
            NotifyObservers();
        });
    }
    // Start is called before the first frame update
    void Start()
    {
    }
  
    List<IObserver<int[]>> _moneyObservers = new List<IObserver<int[]>>();
    public void ResistObserver(IObserver<int[]> observer)
    {
        _moneyObservers.Add(observer);
        if(_moneyObservers.Count>=1)//등록할때 마다 숫자 올려줘야함
        {
            NotifyObservers();
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver<int[]> observer in _moneyObservers) { 
            observer.Set(_money);
        };
    }


    List<IObserver<string>> _profileObservers = new List<IObserver<string>>();

    public void ResistObserver(IObserver<string> observer)
    {
        _profileObservers.Add(observer);
    }

    public void NotifyProfileObservers()
    {
        foreach (IObserver<string> observer in _profileObservers) { observer.Set(_nickName); };
    }
}