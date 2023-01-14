using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusSendMsgObj : MonoBehaviour
{
    [SerializeField] string _message;
    [SerializeField] Flowchart _flowchart;
    public void OnTriggerEnter(Collider other)
    {
        _flowchart.SendFungusMessage(_message);
    }
}
