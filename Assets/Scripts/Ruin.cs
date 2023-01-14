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

    [SerializeField] HammerUI _hammerUI;

    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _clickObject;
    [SerializeField] AudioClip _breakObject;

    public bool CanDestroy;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        RuinMoveStage = this.transform.parent.gameObject;
    }

    public void HitHammer(GameObject destroyObject)
    {
        if (!CanDestroy) return;

        if (IsHammerOnGoing) return;

        if (!_hammerUI.TryDecreaseHammer()) return;


        IsHammerOnGoing = true;

        Vector3 mousePosition;
        mousePosition = Input.mousePosition;
        mousePosition.z = zPos;

        animator.SetTrigger("Hammer");

        _source.PlayOneShot(_clickObject);
        var sequence = DOTween.Sequence();
        sequence.Append(RuinMoveStage.transform.DOMove(Camera.main.ScreenToWorldPoint(mousePosition), 0.4f))
                .AppendInterval(1.3f)
                .Append(RuinMoveStage.transform.DOLocalMove(standbyPosition, 0.6f))
                .OnComplete(() => IsHammerOnGoing = false)
                .InsertCallback(1.0f, () => _source.PlayOneShot(_breakObject))
                .InsertCallback(1.1f,()=>destroyObject.SetActive(false));
    }

    public void EnableDestroy() => CanDestroy = true;

    public void DisableDestroy() => CanDestroy = false;
}
