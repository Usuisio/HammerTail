using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEdgeCollider : MonoBehaviour
{
    [SerializeField] int NextStageNo;
    [SerializeField] StageChanger _stageChanger;
    [SerializeField] GameObject _preventGoBackWall; //��񗈂����͖߂�Ȃ��������

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out _))
        {
            _stageChanger.ChangeToOtherStage(NextStageNo);
            _preventGoBackWall.SetActive(true);
        }
    }
}
