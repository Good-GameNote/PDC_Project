using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageViwer : MonoBehaviour, IObserver<Stage>
{
    [SerializeField]
    TMPro.TextMeshProUGUI stageNum;
    [SerializeField]
    UnityEngine.UI.Text stageNum2;
    [SerializeField]
    UnityEngine.UI.Image[] rewardImgs;

    private void Awake()
    {
        GameManager.Instance._battle.ResistObserver(this);
    }
    public void Set(Stage data)//현재스테이지 
    {
       // stageNum.text = $"Stage {data.stage.index+1}";
        stageNum2.text = $"Stage {data.stage.index + 1}";

    }


}
