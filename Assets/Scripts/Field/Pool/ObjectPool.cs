using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public interface IPool<T>
{
    T Get(int type,  Vector3 position);//특정타입

    T Get(ref Vector3 position);//랜덤타입
    void Release(T obj, int type);
}

public abstract class ObjectPool<T> : Singleton<ObjectPool<T>>, IPool<T> where T : MonoBehaviour
{

    protected  Queue<T>[] poolQueue ;

    [SerializeField]
    protected T[] _prefabs;
    short[] _usingIdx;
    protected virtual void Awake()
    {

        poolQueue = new Queue<T>[_prefabs.Length];
        _usingIdx = new short[_prefabs.Length];
        for (int i = 0; i < _prefabs.Length; i++)
        {
            poolQueue[i] = new Queue<T>();
            _usingIdx[i] =(short) i;
        }

    }
   
    protected void LimitPool(short[] usingIdx)
    {
        _usingIdx = usingIdx;
    }


    public void Clear()
    {
        for (int i = 0; i < _prefabs.Length; i++)
        {
            while (poolQueue[i].Count > 0)
            {
                T obj = poolQueue[i].Dequeue();
                Destroy(obj.gameObject);
            }
        }
    }

    public T Get(int type,  Vector3 position)
    {
        if(type<0||type>=_prefabs.Length)
        {
            Debug.LogWarning($"ObjectPool:: T Get(int type) , type = {type}");
            return null;
        }

        if (poolQueue[type].Count == 0)
        {
            var obj = GameObject.Instantiate(_prefabs[type], position, Quaternion.identity,transform);
            return obj;
        }
        else
        {
            var obj = poolQueue[type].Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
    }
    public T Get(ref Vector3 position)
    {
        int arrIdx = Random.Range(0, _usingIdx.Length);

        int type = _usingIdx[arrIdx];

        if (poolQueue[type].Count == 0)
        {
            var obj = GameObject.Instantiate(_prefabs[type], position, Quaternion.identity,transform);
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
