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

    [field:SerializeField]
    public PacketManager packetManager { get; private set; }
}
