using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ruin : MonoBehaviour
{
    [SerializeField] GameObject RuinMoveStage;
    [SerializeField] Vector3 standbyPosition;
    [SerializeField] float zPos;
    Animator animator;
    bool IsHammerOnGoing;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        RuinMoveStage = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HitHammer(GameObject destroyObject)
    {
        if (IsHammerOnGoing) return;

        IsHammerOnGoing = true;

        Vector3 mousePosition;
        mousePosition = Input.mousePosition;
        mousePosition.z = zPos;

        animator.SetTrigger("Hammer");

        var sequence = DOTween.Sequence();
        sequence.Append(RuinMoveStage.transform.DOMove(Camera.main.ScreenToWorldPoint(mousePosition), 0.4f))
                .AppendInterval(1.3f)
                .Append(RuinMoveStage.transform.DOLocalMove(standbyPosition, 0.6f))
                .OnComplete(() => IsHammerOnGoing = false)
                .InsertCallback(1.1f,()=>destroyObject.SetActive(false));
    }
}
