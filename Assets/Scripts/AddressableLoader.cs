using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableLoader : MonoBehaviour
{

    [SerializeField]
    string[] _spriteAddresses;
    [SerializeField]
    string[] _scriptableObjectAddresses;
    [SerializeField]
    string[] _audioClipAddresses;
    [SerializeField]
    string[] _gameObjectAddresses;

    

    private Dictionary<string, object> _loadedResources = new ();

    [SerializeField]
    TMP_FontAsset tmpFont;
    void OnTMPFontLoaded(AsyncOperationHandle<TMP_FontAsset> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            TMP_FontAsset fontAsset = obj.Result;
            TextMeshProUGUI[] textComponents = FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textComponent in textComponents)
            {
                textComponent.font = fontAsset;
            }
        }
        else
        {
            //Debug.LogError($"Failed to load TMP font asset. Status: {obj.Status}, Address: {obj}");

            TextMeshProUGUI[] textComponents = FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI textComponent in textComponents)
            {
                textComponent.font = tmpFont;
            }
        }
    }

    void Awake()
    {

        //Addressables.LoadAssetAsync<TMP_FontAsset>("tmpFont").Completed += OnTMPFontLoaded;

     

        //StartCoroutine(LoadResources<Sprite>(_spriteAddresses));
        //StartCoroutine(LoadResources<ScriptableObject>(_scriptableObjectAddresses));
        //StartCoroutine(LoadResources<AudioClip>(_audioClipAddresses));
        //StartCoroutine(LoadResources<GameObject>(_gameObjectAddresses));
    }

    IEnumerator LoadResources<T>(string[] addresses)
    {
        for (int i =0; i<= addresses.Length;i++)
        {
            if (i == addresses.Length) continue;
            var handle = Addressables.LoadAssetAsync<T>(addresses[i]);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedResources[addresses[i]] = handle.Result ;

                Debug.Log($"Loaded {typeof(T)} from {addresses[i]}");
            }
            else
            {
                Debug.LogError($"Failed to load {typeof(T)} from {addresses[i]}");
            }
        }
    }

    public T GetLoadedResource<T>(string address)  where T :class
    {
        if (_loadedResources.ContainsKey(address))
        {
            return _loadedResources[address] as T;
        }
        else
        {
            Debug.LogError($"Resource at {address} is not loaded or is of incorrect type");
            return null;
        }
    }


    public IEnumerator LazyLoad<T>(string reciep, Action<T> action)
    {
        AsyncOperationHandle handle = Addressables.LoadAssetAsync<T>(reciep);
        yield return handle;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            action((T)handle.Result);
        }
        else
        {
            Debug.LogError($"Failed to load {reciep}");
        }
    }


}
