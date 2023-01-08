using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEdgeCollider : MonoBehaviour
{
    [SerializeField] int NextStageNo;
    [SerializeField] StageChanger _stageChanger;

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out _))
        {
            _stageChanger.ChangeToOtherStage(NextStageNo);
        }
    }
}
