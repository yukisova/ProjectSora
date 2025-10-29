using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController 
{
    Transform mainCamera;
    Vector3 originPosition;
    Transform chasingTarget;

    public CameraController()
    {
        mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
        originPosition = mainCamera.position;
    }
    public void OnUpdate()
    {
        if (chasingTarget != null)
        {
            mainCamera.position = originPosition + chasingTarget.position;
        }
    }

    public void SetChasingTarget(Transform chasingTarget)
    {
        this.chasingTarget = chasingTarget;
    }
   
}
