using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DGround : MonoBehaviour, IPlayerGroundCollider
{
    public bool IsGround { get; private set; }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = true;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = false;
        }
    }
}
