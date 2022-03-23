using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStateEnum
{
    IDLE,
    RUNNING,
    FALLING,
    JUMPING,
    FLYING
}
public abstract class CharacterState
{
    protected CharacterStateEnum stateType;
    public abstract CharacterStateEnum StateType { get; }
    virtual public CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        return CharacterStateEnum.IDLE;
    }
}
