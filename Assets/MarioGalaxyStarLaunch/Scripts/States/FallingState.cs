using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : RunningState
{
    private float gravity = 20f;

    public FallingState(float _gravity, float _speed, ref CharacterController _controller) : base (_speed, ref _controller)
    {
        this.gravity = _gravity;
    }
    public override CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.FALLING;
    }
}
