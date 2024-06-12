using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AAAA : MonoBehaviour
{
    // 어드레서블 에셋의 주소를 변수로 설정합니다.
    public string addressableAssetName;

    void Start()
    {
        // 어드레서블 에셋 로드 요청을 시작합니다.
        Addressables.LoadAssetAsync<Sprite>(addressableAssetName).Completed += OnLoadDone;
    }

    private void OnLoadDone(AsyncOperationHandle<Sprite> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            // 에셋 로드에 성공하면 인스턴스화합니다.
            Sprite loadedAsset = obj.Result;
            Debug.Log(loadedAsset.ToString());
            Instantiate(loadedAsset);
        }
        else
        {
            // 에셋 로드에 실패하면 에러 메시지를 출력합니다.
            Debug.LogError("Failed to load Addressable asset: " + addressableAssetName);
        }
    }
}
