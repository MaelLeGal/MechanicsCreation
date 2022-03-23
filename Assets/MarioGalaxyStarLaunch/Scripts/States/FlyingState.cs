using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : CharacterState
{
    public override CharacterStateEnum StateType => CharacterStateEnum.FLYING;
    public FlyingState()
    {
    }
    override public CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        return CharacterStateEnum.FLYING;
    }
}
