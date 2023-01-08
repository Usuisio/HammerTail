using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCollider : MonoBehaviour, IPlayerGroundCollider
{
    public bool IsGround { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = true;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IGround>(out _))
        {
            IsGround = false;
        }
    }
}
