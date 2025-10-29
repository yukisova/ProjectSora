using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private GameObject _player;
    private BasicControll _basicControl;

    CameraController cameraController;

    public PlayerController() : base()
    {
        _basicControl = new BasicControll();
        _basicControl.Enable();
        _player = GameObject.FindWithTag("Player");

        cameraController = new CameraController();
        cameraController.SetChasingTarget(_player.transform);
    }

    public void OnUpdate()
    {
        Vector2 moveInput = _basicControl.BasicControl.Move.ReadValue<Vector2>();
        Rigidbody rigidbody = _player.GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(moveInput.x, rigidbody.velocity.y, moveInput.y);

        cameraController.OnUpdate();
    }
}
