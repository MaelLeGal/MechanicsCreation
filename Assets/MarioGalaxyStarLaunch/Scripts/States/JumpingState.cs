using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : RunningState
{
    private float jumpSpeed = 8f;

    public JumpingState(float _jumpSpeed, float _speed, ref CharacterController _controller) : base(_speed, ref _controller)
    {
        this.jumpSpeed = _jumpSpeed;
    }
    public override CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        base.handleInput(ref moveDirection);
        moveDirection.y = jumpSpeed;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.IDLE;
    }
}
