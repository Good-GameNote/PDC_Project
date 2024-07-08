
using UnityEngine;
using static Common;




public class GotoBattle : Singleton<GotoBattle>
{
    [SerializeField]
    GameObject _loading;
    private void Awake()
    {

    }

    public void CanIEnter()
    {
        CP_CanI cp = new CP_CanI(0);
        cp._type = (short) eCanI.eEnterBattle;
        GameManager.Instance._packetManager.Send(cp, cp._size);
    }

    public void Enter()
    {
        _loading.SetActive(true);
    }


}
