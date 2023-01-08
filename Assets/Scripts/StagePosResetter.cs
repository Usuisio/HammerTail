using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StagePosResetter : MonoBehaviour
{
    [SerializeField] List<GameObject> stages;

    [SerializeField] float resetUpperPos = 30f;
    [SerializeField] GameObject ResetUI;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    public void Reset()
    {
        int upperLower = 1;
        if(ResetUI.transform.position.y > 0)
        {
            upperLower = -1;
        }

        Sequence sequence = DOTween.Sequence();
        sequence.Append(ResetUI.transform.DOMoveY(0, 0.5f))
                .InsertCallback(0.5f, () => ResetStagesPos())
                .Append(ResetUI.transform.DOMoveY(resetUpperPos * upperLower, 0.5f));
    }

    public void ResetStagesPos()
    {
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
