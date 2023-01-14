using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSignal : MonoBehaviour
{
    [SerializeField] StagePosResetter _resetter;
    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Player>(out _))
        {
            _resetter.Reset();
        }
    }
}
