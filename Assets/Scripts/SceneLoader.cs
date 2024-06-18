using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    string _sceneAddress; // Addressables 씬 주소
    TMPro.TextMeshProUGUI _progressText;   // 진행 상황을 표시할 UI 텍스트
    Slider _progressBar;  // 진행 상황을 표시할 UI 슬라이더
    bool _autoNext;
    Button _button;

public void LoadScene(string sceneAddress, TMPro.TextMeshProUGUI progressText, Slider progressBar, bool autoNext,Button button)
    {
        _sceneAddress = sceneAddress;
        _progressText = progressText;
        _progressBar = progressBar;
        _autoNext = autoNext;
        if(autoNext==false)
        {
            _button = button;
            _button.onClick.AddListener(() => {
                if (_autoNext)
                {
                    _loadedScene.ActivateAsync();
                };
            });
        }

        StartCoroutine(LoadSceneAsync());
    }
    private SceneInstance _loadedScene;

    IEnumerator LoadSceneAsync()
    {
        AsyncOperationHandle downloadSizeHandle = Addressables.GetDownloadSizeAsync(_sceneAddress);
        yield return downloadSizeHandle;

        if (downloadSizeHandle.Status == AsyncOperationStatus.Succeeded)
        {
           long totalSizeInBytes = (long)downloadSizeHandle.Result;
            _progressText.text = $"Total Size: {FormatBytes(totalSizeInBytes)}";

            if (totalSizeInBytes > 0)
            {
                AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync(_sceneAddress);
                while (!downloadHandle.IsDone)
                {
                    _progressBar.value = downloadHandle.PercentComplete;
                    _progressText.text = $"Downloading: {downloadHandle.PercentComplete * 100:F2}%\nSize: {FormatBytes((long)(totalSizeInBytes * downloadHandle.PercentComplete))} / {FormatBytes(totalSizeInBytes)}";
                    yield return null;
                }

                if (downloadHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    _progressText.text = "Download completed. Loading scene...";

                    AsyncOperationHandle<SceneInstance> loadSceneHandle = Addressables.LoadSceneAsync(_sceneAddress, LoadSceneMode.Single, _autoNext);
                    
                    while (!loadSceneHandle.IsDone)
                    {
                        _progressBar.value = loadSceneHandle.PercentComplete;
                        _progressText.text = $"Loading Scene: {loadSceneHandle.PercentComplete * 100:F2}%";
                        yield return null;
                    }

                    if (loadSceneHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        _progressBar.value = loadSceneHandle.PercentComplete;
                        _loadedScene = loadSceneHandle.Result;
                        _progressText.text = "Press any key to continue.";
                        _autoNext= true;
                    }
                    else
                    {
                        _progressText.text = "Scene loading failed.";
                    }
                }
                else
                {
                    _progressText.text = "Download failed.";
                }
            }
            else
            {
                _progressText.text = "No download required. Loading scene...";

                AsyncOperationHandle<SceneInstance> loadSceneHandle = Addressables.LoadSceneAsync(_sceneAddress, LoadSceneMode.Single, _autoNext);

                while (!loadSceneHandle.IsDone)
                {
                    _progressBar.value = loadSceneHandle.PercentComplete;
                    _progressText.text = $"Loading Scene: {loadSceneHandle.PercentComplete * 100:F2}%";
                    yield return null;
                }

                if (loadSceneHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    _progressBar.value = loadSceneHandle.PercentComplete;
                    _loadedScene = loadSceneHandle.Result;
                    _progressText.text = "Press any key to continue.";
                    _autoNext = true;
                }
                else
                {
                    _progressText.text = "Scene loading failed.";
                }
            }
        }
        else
        {
            _progressText.text = "Failed to get download size.";
        }
    }

    public string FormatBytes(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB"};
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }


  
}
