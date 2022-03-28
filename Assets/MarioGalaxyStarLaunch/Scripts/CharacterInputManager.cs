using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputManager : MonoBehaviour
{
    public Character character;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public event PlayerTriggeredStarLauncher starLauncherTriggerEvent;

    public GameObject testPlayer;

    // Start is called before the first frame update
    void Start()
    {
        controller = character.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

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

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 playerDirection = horizontal * Camera.main.transform.right + vertical * Camera.main.transform.forward;
            testPlayer.transform.rotation = Quaternion.LookRotation(playerDirection);
        }

    }

    public delegate void PlayerTriggeredStarLauncher(Character character);
}
