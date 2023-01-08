using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    [SerializeField] List<GameObject> VirtualCameras;
    [SerializeField] List<int> HammerCount;

    public void ChangeToOtherStage(int stageNo)
    {
        //�Y��No�̃J�����̂�Active�ɂ���
        for (int i = 0; i < VirtualCameras.Count; i++)
        {
            VirtualCameras[i].SetActive(i == stageNo);
        }
        
    }
}
