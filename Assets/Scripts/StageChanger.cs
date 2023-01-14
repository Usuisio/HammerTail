using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    public int StageNo;
    [SerializeField] List<GameObject> VirtualCameras;
    [SerializeField] List<int> HammerCount;
    [SerializeField] List<GameObject> PlayerResetPos;

    [SerializeField] HammerUI _hammerUI;
    public void ChangeToOtherStage(int stageNo)
    {
        if (StageNo == stageNo) return;

        StageNo = stageNo;
        //�Y��No�̃J�����̂�Active�ɂ���
        for (int i = 0; i < VirtualCameras.Count; i++)
        {
            VirtualCameras[i].SetActive(i == stageNo);
        }

        _hammerUI.SetHammers(HammerCount[StageNo]);
    }

    public void ResetHammerUI()
    {
        _hammerUI.SetHammers(HammerCount[StageNo]);
    }

    public Vector3 GetNowStagePlayerResetPos() => PlayerResetPos[StageNo].transform.position;
}
