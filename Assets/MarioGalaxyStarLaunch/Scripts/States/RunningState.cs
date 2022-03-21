using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunningState : CharacterState
{
    protected float speed = 10f;

    public RunningState(float _speed, ref CharacterController _controller)
    {
        this.speed = _speed;
        this.controller = _controller;
    }
    public override CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        moveDirection = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
        moveDirection.y = 0f;
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.RUNNING;
    }
}
