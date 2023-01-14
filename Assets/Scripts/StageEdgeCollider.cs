using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEdgeCollider : MonoBehaviour
{
    [SerializeField] int NextStageNo;
    [SerializeField] StageChanger _stageChanger;
    [SerializeField] GameObject _preventGoBackWall; //ˆê‰ñ—ˆ‚½“¹‚Í–ß‚ê‚È‚­‚·‚é‚à‚Ì

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out _))
        {
            _stageChanger.ChangeToOtherStage(NextStageNo);
            _preventGoBackWall.SetActive(true);
        }
    }
}
