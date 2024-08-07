using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>(true);
                if (instance == null)
                {
                    GameObject singletonObj = new GameObject();
                    instance = singletonObj.AddComponent<T>();
                    singletonObj.name = typeof(T).ToString() + " (Singleton)";

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
