using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public interface IPool<T>
{
    T Get(int type);
    void Release(T obj, int type);
}

public abstract class ObjectPool<T> : MonoBehaviour, IPool<T> where T : MonoBehaviour
{

    protected  Queue<T>[] poolQueue ;

    [SerializeField]
    protected T[] prefabs;

    protected void Init()
    {
        poolQueue = new Queue<T>[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            var obj = Instantiate(prefabs[i], transform);
            obj.gameObject.SetActive(false);
            poolQueue[i].Enqueue(obj);
        }    
    }


    public void Clear()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            while (poolQueue[i].Count > 0)
            {
                T obj = poolQueue[i].Dequeue();
                Destroy(obj.gameObject);
            }
        }
    }

    public T Get(int type)
    {
        if(type<0||type>=prefabs.Length)
        {
            Debug.LogWarning($"ObjectPool:: T Get(int type) , type = {type}");
            return null;
        }

        if (poolQueue[type].Count == 0)
        {
            var obj = GameObject.Instantiate(prefabs[type], transform);
            return obj;
        }
        else
        {
            var obj = poolQueue[type].Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
    }


    public void Release(T obj, int type)
    {
        obj.gameObject.SetActive(false);
        poolQueue[type].Enqueue(obj);
    }
}
