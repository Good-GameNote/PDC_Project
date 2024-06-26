using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static readonly object lockObj = new object();
    private static bool applicationIsQuitting = false;

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed on application quit. Won't create again - returning null.");
                return null;
            }

            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        GameObject singletonObj = new GameObject();
                        instance = singletonObj.AddComponent<T>();
                        singletonObj.name = typeof(T).ToString() + " (Singleton)";

                        DontDestroyOnLoad(singletonObj);

                        Debug.Log($"[Singleton] An instance of {typeof(T)} is needed in the scene, so '{singletonObj}' was created.");
                    }
                    else
                    {
                        Debug.Log($"[Singleton] Using instance already created: {instance.gameObject.name}");
                    }
                }

                return instance;
            }
        }
    }


    private void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }

    private void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
