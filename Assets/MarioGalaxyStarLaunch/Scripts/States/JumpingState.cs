using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : CharacterState
{
    public float jumpSpeed = 8f;
    public override CharacterStateEnum StateType => CharacterStateEnum.JUMPING;

    public JumpingState()
    {

    }

    public override CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        //base.handleInput(ref moveDirection);
        moveDirection.y = jumpSpeed;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.IDLE;
    }
}
