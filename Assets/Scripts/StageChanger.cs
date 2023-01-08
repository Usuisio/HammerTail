using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChanger : MonoBehaviour
{
    [SerializeField] List<GameObject> VirtualCameras;
    [SerializeField] List<int> HammerCount;

    public void ChangeToOtherStage(int stageNo)
    {
        //ŠY“–No‚ÌƒJƒƒ‰‚Ì‚İActive‚É‚·‚é
        for (int i = 0; i < VirtualCameras.Count; i++)
        {
            VirtualCameras[i].SetActive(i == stageNo);
        }
        
    }
}
