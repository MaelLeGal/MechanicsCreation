using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : CharacterState
{
    public float gravity = 20f;

    public override CharacterStateEnum StateType => CharacterStateEnum.FALLING;

    public FallingState()
    {

    }

    public override CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.FALLING;
    }
}
