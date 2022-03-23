using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RunningState : CharacterState
{
    public float speed = 10f;
    public override CharacterStateEnum StateType => CharacterStateEnum.RUNNING;

    public RunningState()
    {

    }

    public override CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        moveDirection = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * Camera.main.transform.forward;
        moveDirection.y = 0f;
        moveDirection *= speed;
        controller.Move(moveDirection * Time.deltaTime);
        return CharacterStateEnum.RUNNING;
    }
}
