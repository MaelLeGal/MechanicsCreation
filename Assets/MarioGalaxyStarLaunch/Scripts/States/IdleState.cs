using UnityEngine;

public class IdleState : CharacterState
{

    public IdleState() { }
    public override CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        return CharacterStateEnum.IDLE;
    }
}
