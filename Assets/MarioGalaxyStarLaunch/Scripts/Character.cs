using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterState state;
    public CharacterStateEnum State { get {
            return statesEnum[state];
        }
    }


    private Dictionary<CharacterStateEnum,CharacterState> states = new Dictionary<CharacterStateEnum, CharacterState>();
    private Dictionary<CharacterState, CharacterStateEnum> statesEnum = new Dictionary<CharacterState, CharacterStateEnum>();

    [SerializeField]
    private CharacterController controller;
    public float speed = 10f;
    public float jumpSpeed = 8f;
    private float gravity = 20f;
    public bool isGrounded { get => controller.isGrounded; }

    private void Awake()
    {
        IdleState idleState = new IdleState();
        RunningState runningState = new RunningState(speed, ref controller);
        FallingState fallingState = new FallingState(gravity, speed, ref controller);
        JumpingState jumpingState = new JumpingState(jumpSpeed, speed, ref controller);
        FlyingState flyingState = new FlyingState();

        states.Add(CharacterStateEnum.IDLE, idleState);
        states.Add(CharacterStateEnum.RUNNING, runningState);
        states.Add(CharacterStateEnum.FALLING, fallingState);
        states.Add(CharacterStateEnum.JUMPING, jumpingState);
        states.Add(CharacterStateEnum.FLYING, flyingState);

        statesEnum.Add(idleState,CharacterStateEnum.IDLE);
        statesEnum.Add(runningState, CharacterStateEnum.RUNNING);
        statesEnum.Add(fallingState, CharacterStateEnum.FALLING);
        statesEnum.Add(jumpingState, CharacterStateEnum.JUMPING);
        statesEnum.Add(flyingState, CharacterStateEnum.FLYING);

        state = states[CharacterStateEnum.FALLING]; 
    }

    public void SetNewState(CharacterStateEnum newState)
    {
        state = states[newState];
    }

    public CharacterStateEnum handleInput(ref Vector3 moveDirection)
    {
        return state.handleInput(ref moveDirection);
    }
}
