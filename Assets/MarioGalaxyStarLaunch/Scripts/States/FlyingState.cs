using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : CharacterState
{

    public FlyingState()
    {
    }
    override public CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        return CharacterStateEnum.FLYING;
    }
}
