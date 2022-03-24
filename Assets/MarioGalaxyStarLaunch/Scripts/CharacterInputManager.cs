using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    public Character character;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public event PlayerTriggeredStarLauncher starLauncherTriggerEvent;

    // Start is called before the first frame update
    void Start()
    {
        controller = character.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(character.isGrounded);
        if (character.State != CharacterStateEnum.FLYING)
        {
            if (character.isGrounded)
            {
                if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
                {
                    character.SetNewState(CharacterStateEnum.RUNNING);
                }
                else
                {
                    character.SetNewState(CharacterStateEnum.FALLING);
                }

                if (Input.GetButton("Jump"))
                {
                    character.SetNewState(CharacterStateEnum.JUMPING);
                }

            }
            else
            {
                character.SetNewState(CharacterStateEnum.FALLING);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (starLauncherTriggerEvent != null)
                {
                    starLauncherTriggerEvent(character);
                }
            }
        }

        character.SetNewState(character.handleInput(ref controller, ref moveDirection));
    }

    public delegate void PlayerTriggeredStarLauncher(Character character);
}
