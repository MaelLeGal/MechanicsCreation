using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField]
    private CharacterState state;
    public CharacterStateEnum State => state.StateType;

    private static Dictionary<CharacterStateEnum, CharacterState> states = new Dictionary<CharacterStateEnum, CharacterState>();

    [SerializeField]
    private CharacterController controller;
    public float speed = 10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public bool isGrounded { get => controller.isGrounded; }

    private void Awake()
    {

        var allStatesTypes = Assembly.GetAssembly(typeof(CharacterState)).GetTypes()
                                .Where(t => typeof(CharacterState).IsAssignableFrom(t) && t.IsAbstract == false);

        foreach(var stateType in allStatesTypes)
        {
            CharacterState state = Activator.CreateInstance(stateType) as CharacterState;
            states.Add(state.StateType, state);
        }

        InitializeStatesFields();

        state = states[CharacterStateEnum.FALLING];
    }

    public void SetNewState(CharacterStateEnum newState)
    {
        state = states[newState];
    }

    public CharacterStateEnum handleInput(ref CharacterController controller, ref Vector3 moveDirection)
    {
        return state.handleInput(ref controller, ref moveDirection);
    }

    public void InitializeStatesFields()
    {
        //Painfull to do... Is there a better way ?
        (states[CharacterStateEnum.FALLING] as FallingState).gravity = gravity;
        (states[CharacterStateEnum.RUNNING] as RunningState).speed = speed;
        (states[CharacterStateEnum.JUMPING] as JumpingState).jumpSpeed = jumpSpeed;
    }
}
