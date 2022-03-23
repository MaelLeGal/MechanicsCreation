using UnityEngine;

public class IdleState : CharacterState
{
    public override CharacterStateEnum StateType => CharacterStateEnum.IDLE;
    public IdleState() { } 

    public override CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        return CharacterStateEnum.IDLE;
    }
}
