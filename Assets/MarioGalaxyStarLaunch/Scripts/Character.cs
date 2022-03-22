using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterState state;
    public CharacterState State { get => state;}
    private Dictionary<CharacterStateEnum,CharacterState> states = new Dictionary<CharacterStateEnum, CharacterState>();

    [SerializeField]
    private CharacterController controller;
    public float speed = 10f;
    public float jumpSpeed = 8f;
    private float gravity = 20f;
    public bool isGrounded { get => controller.isGrounded; }

    public void Awake()
    {
        states.Add(CharacterStateEnum.IDLE, new IdleState());
        states.Add(CharacterStateEnum.RUNNING, new RunningState(speed, ref controller));
        states.Add(CharacterStateEnum.FALLING, new FallingState(gravity, speed, ref controller));
        states.Add(CharacterStateEnum.JUMPING, new JumpingState(jumpSpeed, speed, ref controller));

        state = states[CharacterStateEnum.FALLING]; 
    }

    public void SetNewState(CharacterStateEnum newState)
    {
        state = states[newState];
    }
}
