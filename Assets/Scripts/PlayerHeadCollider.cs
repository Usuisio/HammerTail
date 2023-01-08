using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadCollider : MonoBehaviour,IPlayerHeadCollider
{
    public bool IsHead { get; private set; }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            IsHead = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            IsHead = false;
        }
    }
}
