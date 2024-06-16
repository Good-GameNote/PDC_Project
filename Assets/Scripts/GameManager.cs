using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) Initialize();
            return instance;
        }
    }

    private void Awake()
    {
        Initialize();
        if (instance != null && instance != this) Destroy(gameObject);
    }

    static void Initialize()
    {
        GameObject managers = GameObject.Find("GameManager") ?? new GameObject("GameManager");
        managers.TryGetComponent(out instance);
        DontDestroyOnLoad(instance);
    }

    [field: SerializeField]
    public AddressableLoader _addressableLoader { get; private set; }

    [field:SerializeField]
    public PacketManager _packetManager { get; private set; }
    [field:SerializeField]
    public PageController _pageController { get; private set; }
    [field: SerializeField]
    public Player _player { get; private set; }
    [field: SerializeField]
    public Inventory _inven { get; private set; }
    [field: SerializeField]
    public Battle _battle { get; private set; }
    [field: SerializeField]
    public Team _team { get; private set; }
    [field: SerializeField]
    public Town _town { get; private set; }
    
}
