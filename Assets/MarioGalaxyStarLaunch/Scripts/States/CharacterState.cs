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
public class CharacterState
{
    protected CharacterController controller;
    virtual public CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        return CharacterStateEnum.IDLE;
    }
}
