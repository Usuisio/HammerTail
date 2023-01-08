using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;
    [SerializeField] GameObject vcam1;
    [SerializeField] GameObject vcam2;

    public void ChangeToPerspecive() => _mainCamera.orthographic = false;

    public void ChangeToOrtographic() => _mainCamera.orthographic = true;

    public void Button1()
    {
        ChangeToOrtographic();
        vcam2.SetActive(false);
    }
}
