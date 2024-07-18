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


    [SerializeField]
    UnityEngine.UI.Button left;
    [SerializeField]
    UnityEngine.UI.Button right;

    private void Awake()
    {
        GameManager.Instance._battle.ResistObserver(this);
        left.onClick.AddListener(() => { GameManager.Instance._battle.ChangeStage(false); });
        right.onClick.AddListener(() => { GameManager.Instance._battle.ChangeStage(true); });
    }
    public void Set(Stage data)//현재스테이지 
    {
        // stageNum.text = $"Stage {data.stage.index+1}";
        if (stageNum2 == null)
            return;
        stageNum2.text = $"Stage {data.stage.index + 1}";

    }


}
