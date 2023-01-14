using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StagePosResetter : MonoBehaviour
{
    [SerializeField] List<GameObject> stages;

    [SerializeField] float resetUpperPos = 30f;
    [SerializeField] GameObject ResetUI;

    [SerializeField] GameObject Player;
    [SerializeField] StageChanger _stageChanger;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _resetClip;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Reset()
    {
        _audioSource.PlayOneShot(_resetClip);

        int upperLower = 1;
        if(ResetUI.transform.position.y > 0)
        {
            upperLower = -1;
        }

        Sequence sequence = DOTween.Sequence();
        sequence.Append(ResetUI.transform.DOMoveY(0, 0.4f))
                .InsertCallback(0.4f, () => ResetStagesPos())
                .AppendInterval(0.2f)
                .Append(ResetUI.transform.DOMoveY(resetUpperPos * upperLower, 0.4f));
    }

    public void ResetStagesPos()
    {
        Player.transform.position = _stageChanger.GetNowStagePlayerResetPos();

        _stageChanger.ResetHammerUI();

        foreach (var item in stages)
        {
            for (int i = 0; i < item.transform.childCount; i++)
            {
                var child = item.transform.GetChild(i);
                child.gameObject.SetActive(true);
                child.transform.localPosition = Vector3.zero;
            }
        }
    }
}
