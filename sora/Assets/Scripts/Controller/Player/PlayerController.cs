using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: AController
{
    private GameObject _player;
    private Transform _playerTransform;
    private BasicControll _basicControl;

    GridXZBuild gridBuildingSystem;
    int currentX;
    int currentZ;


    /// <summary>
    /// 已经过去的时间
    /// </summary>
    private float passDelta;

    CameraController cameraController;

    public PlayerController() : base(){}
    protected override void OnInit()
    {
        base.OnInit();

        _basicControl = new BasicControll();
        _basicControl.Enable();
        _player = GameObject.FindWithTag("Player");

        cameraController = new CameraController();
        cameraController.SetChasingTarget(_player.transform);

        GameObject gameLoop = GameObject.Find("GameLoop");
        gridBuildingSystem = gameLoop.GetComponent<GridXZBuild>();

        currentX = 0;
        currentZ = 0;
        _playerTransform = _player.transform;
        UpdatePosition();
    }

    protected override void AlwaysUpdate()
    {
        Vector2 moveInput = _basicControl.BasicControl.Move.ReadValue<Vector2>();
        passDelta += Time.deltaTime;
        if (passDelta > 1)
        {
            passDelta %= 1;
            if (moveInput.magnitude > 0)
            {
                currentX += (int)moveInput.x;
                currentZ += (int)moveInput.y;
                UpdatePosition();
            }
        }

        cameraController.OnUpdate();
    }

    private void UpdatePosition()
    {
        float originY = _playerTransform.position.y;
        _playerTransform.position = gridBuildingSystem.grid.GetWorldPosition(currentX, currentZ) + gridBuildingSystem.grid.GetCellHalfSize();
        _playerTransform.position = new Vector3(_playerTransform.position.x, originY, _playerTransform.position.z);
 
    }
}
