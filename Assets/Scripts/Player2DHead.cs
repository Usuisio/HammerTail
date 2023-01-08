using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DHead : MonoBehaviour, IPlayerHeadCollider
{
    public bool IsHead { get; private set; }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            IsHead = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            IsHead = false;
        }
    }
}