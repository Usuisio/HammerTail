using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    private float horizontal;
    [SerializeField] private LayerMask m_WhatIsGround;

    [SerializeField] private float velocity = 3f;
    [SerializeField] private float jumpForce = 6.6f;
    [SerializeField] private float eps = 0.1f;

    [SerializeField] GameObject _moveStand;
    [SerializeField] Player2DGround _playerGroundCollider;
    [SerializeField] Player2DHead _playerHeadCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = _moveStand.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var foot_pos = new Vector3(transform.position.x, transform.position.y - 0.51f, 0);
        bool floating = (Physics.OverlapSphere(foot_pos, m_WhatIsGround).Length == 0);

        bool isGround = _playerGroundCollider.IsGround;

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            MoveJump();
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        MoveHorizontal();

        ChangeAnimation();
    }

    public void MoveHorizontal()
    {
        var vel = rb.velocity;
        vel.x = horizontal * velocity;
        rb.velocity = vel;

        if (horizontal < -eps)
        {
            this.transform.DORotate(new Vector3(0f, 0f, 0f), 0.5f);
        }
        else if (eps < horizontal)
        {
            this.transform.DORotate(new Vector3(0f, 180f, 0f), 0.5f);
        }
    }

    public void ChangeAnimation()
    {
        animator.SetBool("IsBear", _playerHeadCollider.IsHead);

        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Jump");
        animator.ResetTrigger("Fall");
        if (rb.velocity.y > eps)
        {
            animator.SetTrigger("Jump");
            return;
        }
        if (rb.velocity.y < -eps)
        {
            animator.SetTrigger("Fall");
            return;
        }

        if (Mathf.Abs(horizontal) < eps)
        {
            if (!_playerGroundCollider.IsGround) return;
            animator.SetTrigger("Idle");
        }
        else
        {
            animator.SetTrigger("Run");
        }
    }

    public void MoveJump()
    {
        rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode2D.Impulse);
    }
}

internal interface IPlayerHeadCollider
{
    bool IsHead { get; }
}

internal interface IPlayerGroundCollider
{
    bool IsGround { get; }
}